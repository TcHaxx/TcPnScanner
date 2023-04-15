using dsian.TcPnScanner.CLI.Packets;
using dsian.TcPnScanner.CLI.PnDevice;
using Microsoft.Extensions.Logging;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;

namespace dsian.TcPnScanner.CLI;

internal sealed class Capture : ICapture
{
    private ILogger? _logger;
    private bool _disposed;
    private ulong _packetIndex;
    private IPacketHandler? _packetHandler;
    private bool _stopped;
    private TimeSpan _captureTimeout = TimeSpan.FromSeconds(180);
    private CaptureFileWriterDevice? _captureFileWriterDevice;

    internal int ReadTimeoutMilliseconds { get; set; } = 1000;
    internal ICaptureDeviceProxy? CaptureDeviceProxy { get; private set; }

    private Capture()
    {
    }

    ~Capture()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                DisposeCaptureDevice();
            }
            _disposed = true;
        }
    }

    public static ICapture Create()
    {
        return new Capture();
    }
    public ICapture WithCapturingDevice(ICaptureDeviceProxy capDeviceProxy)
    {
        Guard.ThrowIfNull(capDeviceProxy);

        CaptureDeviceProxy = capDeviceProxy;
        CaptureDeviceProxy.PcapDevice.OnPacketArrival += CaptureDevice_OnPacketArrival;
        CaptureDeviceProxy.PcapDevice.OnCaptureStopped += CaptureDevice_OnCaptureStopped;
        CaptureDeviceProxy.OnPacketSend += CaptureDeviceProxy_OnPacketSend;
        return this;
    }

    public ICapture WithEthernetPacketHandler(IPacketHandler packetHandler)
    {
        Guard.ThrowIfNull(packetHandler);
        _packetHandler = packetHandler;
        return this;
    }

    public ICapture WithCaptureFileWriterDevice(CaptureFileWriterDevice? libCaptureFileWriterDevice)
    {
        if (libCaptureFileWriterDevice is null)
        {
            return this;
        }

        _captureFileWriterDevice = libCaptureFileWriterDevice;
        return this;
    }

    public ICapture WithLogger(ILogger? logger)
    {
        _logger = logger;
        logger?.BeginScope(this);
        return this;
    }

    public void StartCapture()
    {
        _stopped = false;
        Guard.ThrowIfNull(CaptureDeviceProxy);
        _logger?.LogInformation("Opening capture device '{CaptureDeviceName}'...", CaptureDeviceProxy.Name);
        CaptureDeviceProxy.Open(mode: DeviceModes.Promiscuous | DeviceModes.DataTransferUdp | DeviceModes.NoCaptureLocal, read_timeout: ReadTimeoutMilliseconds);
        _captureFileWriterDevice?.Open(CaptureDeviceProxy.PcapDevice);
        _logger?.LogInformation("Listening on {CaptureDeviceName}...", CaptureDeviceProxy.Name);
        CaptureDeviceProxy.PcapDevice.StartCapture();
    }

    public async Task StartCaptureAndWaitUntilFininshed(TimeSpan? timeout = null)
    {
        timeout ??= _captureTimeout;

        StartCapture();

        await Task.Run(async () =>
        {
            await WaitUntilFinished(timeout);
        });
    }

    public void StopCapture()
    {
        _captureFileWriterDevice?.Close();
        CaptureDeviceProxy?.PcapDevice.StopCapture();
        CaptureDeviceProxy?.Close();
    }

    private void CaptureDevice_OnPacketArrival(object sender, PacketCapture e)
    {

        var rawPacket = e.GetPacket();


        if (rawPacket.LinkLayerType != LinkLayers.Ethernet)
        {
            return;
        }
        var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
        var ethernetPacket = (EthernetPacket)packet;

        _logger?.LogInformation("{PacketIndex} At: {Date}:{Millis}: MAC:{SrcHWAddress} -> MAC:{DstHWAddress} TYP:{PacketType} LEN:{TotalPacketLength}",
                          _packetIndex,
                          rawPacket.Timeval.Date.ToString(),
                          rawPacket.Timeval.Date.Millisecond,
                          ethernetPacket.SourceHardwareAddress,
        ethernetPacket.DestinationHardwareAddress,
                          ethernetPacket.Type,
        ethernetPacket.TotalPacketLength);
        _logger?.LogDebug("{PacketIndex} content:\n{PacketContentHex}", _packetIndex, rawPacket.GetPacket().PrintHex());
        _packetIndex++;

        _captureFileWriterDevice?.Write(rawPacket);

        _packetHandler?.HandleEthernetPacket(ethernetPacket);
    }

    private void CaptureDevice_OnCaptureStopped(object sender, CaptureStoppedEventStatus status)
    {
        _stopped = true;
    }

    private async Task WaitUntilFinished(TimeSpan? timeout)
    {
        var sw = Stopwatch.StartNew();
        while (!_stopped)
        {
            await Task.Delay(100);
            if (sw.Elapsed > timeout)
            {
                StopCapture();
                _logger?.LogWarning("Stopped capturing due to timeout of {TimeOut}s", timeout?.Seconds ?? 0);
            }
        }
    }
    private void CaptureDeviceProxy_OnPacketSend(object? sender, Packet e)
    {
        _captureFileWriterDevice?.Write(e.Bytes);
    }

    private void DisposeCaptureDevice()
    {
        if (CaptureDeviceProxy is null)
        {
            return;
        }

        if (CaptureDeviceProxy.PcapDevice.Started)
        {
            CaptureDeviceProxy.PcapDevice.StopCapture();
        }
        CaptureDeviceProxy.Dispose();
    }
}
