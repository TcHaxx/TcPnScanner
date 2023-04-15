
using dsian.TcPnScanner.CLI.Export;
using dsian.TcPnScanner.CLI.Export.TC;
using dsian.TcPnScanner.CLI.Packets;
using dsian.TcPnScanner.CLI.PnDevice;
using Microsoft.Extensions.Logging;
using SharpPcap.LibPcap;

namespace dsian.TcPnScanner.CLI;

internal sealed class Process
{
    private LibPcapLiveDevice? _libPcapLiveDevice;
    private readonly CliOptions _cliOptions;
    private readonly ILogger? _logger;

    internal Process(CliOptions cliOptions, ILogger? logger)
    {
        Guard.ThrowIfNull(cliOptions);
        _cliOptions = cliOptions;
        _logger = logger;
    }

    internal async Task Start()
    {

        var capDevice = SelectCaptureDevice();
        Guard.ThrowIfNull(capDevice);

        var deviceStore = new DeviceStore();
        using var cap = Capture.Create()
            .WithCapturingDevice(capDevice)
            .WithEthernetPacketHandler(new PacketHandler(capDevice, deviceStore, _logger))
            .WithCaptureFileWriterDevice(GetCaptureFileWriter(_cliOptions))
            .WithLogger(_logger);

        Guard.ThrowIfNull(cap);

        await cap.StartCaptureAndWaitUntilFininshed(TimeSpan.FromSeconds(_cliOptions.Timeout_s));

        await Export(deviceStore);

    }

    private CaptureFileWriterDevice? GetCaptureFileWriter(CliOptions cliOptions)
    {
        if (!cliOptions.DumpPcap)
        {
            return null;
        }

        var pcapDumpFile = cliOptions.DumpPcapFile;
        pcapDumpFile = pcapDumpFile.Replace(Constants.TEMP_DIR_TEMPLATE, Path.GetTempPath());
        pcapDumpFile = pcapDumpFile.Replace(Constants.APPNAME_TEMPLATE, AssemblyHelper.Name);
        pcapDumpFile = pcapDumpFile.Replace(Constants.TIMESTAMP_TEMPLATE, DateTime.Now.ToString(Constants.TIMESTAMP_TEMPLATE));

        return new CaptureFileWriterDevice(pcapDumpFile);
    }

    private ICaptureDeviceProxy? SelectCaptureDevice()
    {
        ThrowIfOutputRedirected(_cliOptions);

        if (!string.IsNullOrWhiteSpace(_cliOptions.PcapFile))
        {
            return new CaptureDeviceProxy(new CaptureFileReaderDevice(_cliOptions.PcapFile));
        }

        var pcapDevice = GetCaptureDeviceByNameOrAskUser(_cliOptions.CaptureDevice);
        Guard.ThrowIfNull(pcapDevice);
        _libPcapLiveDevice = pcapDevice as LibPcapLiveDevice;
        Guard.ThrowIfNull(_libPcapLiveDevice);

        var capDevice = new CaptureDeviceProxy(pcapDevice, (p) =>
        {
            _libPcapLiveDevice.SendPacket(p.Bytes);
        });
        _logger?.LogInformation($"🎤 Selected Capture Device '{capDevice.Name}{(!string.IsNullOrWhiteSpace(capDevice.Description) ? $": {capDevice.Description}" : string.Empty)}'");

        return capDevice;
    }

    private PcapDevice GetCaptureDeviceByNameOrAskUser(string selectedFromCLI)
    {
        if (string.IsNullOrEmpty(selectedFromCLI))
        {
            return CaptureDevices.AskUserForCapDevice();
        }

        return CaptureDevices.FindByName(selectedFromCLI);
    }

    private void ThrowIfOutputRedirected(CliOptions cliOptions)
    {
        if (!Console.IsOutputRedirected)
        {
            return;
        }

        if (!string.IsNullOrEmpty(cliOptions.CaptureDevice))
        {
            return;
        }

        if (!string.IsNullOrEmpty(cliOptions.PcapFile))
        {
            return;
        }

        throw new ArgumentException("Provide option '-d'/'--capture-device' or '-f'/'--pcap-file' if Console output is redirected");
    }

    private async Task Export(DeviceStore deviceStore)
    {
        await Exporter.ExportToFile(new XtiExporter(), deviceStore, _cliOptions, _logger);

        if (Console.IsOutputRedirected)
        {
            await Exporter.ExportToCLI(new XtiExporter(), deviceStore, _cliOptions);
        }
    }
}
