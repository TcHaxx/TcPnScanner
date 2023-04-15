using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Net.NetworkInformation;

namespace dsian.TcPnScanner.CLI;

internal class CaptureDeviceProxy : ICaptureDeviceProxy
{
    private Action<Packet>? _sendPacketHandler = default;
    private PhysicalAddress _macAddress;

    public event EventHandler<Packet>? OnPacketSend;

    public PcapDevice PcapDevice { get; init; }

    public string Name => PcapDevice.Name;

    public string Description => PcapDevice.Description;

    public string LastError => PcapDevice.LastError;

    public string Filter { get => PcapDevice.Filter; set => PcapDevice.Filter = value; }

    public PhysicalAddress MacAddress => _macAddress;

    public LinkLayers LinkType => PcapDevice.LinkType;

    public CaptureDeviceProxy(PcapDevice pcapDevice, Action<Packet>? sendPacketHandler = null)
    {
        PcapDevice = pcapDevice ?? throw new ArgumentNullException(nameof(pcapDevice));
        _macAddress = pcapDevice is CaptureFileReaderDevice ? PhysicalAddress.None : pcapDevice.MacAddress;
        _sendPacketHandler = sendPacketHandler;
    }

    public void SendPacketHandler(Packet p)
    {
        OnPacketSend?.Invoke(this, p);
        _sendPacketHandler?.Invoke(p);
    }

    public void Open(DeviceConfiguration configuration)
    {
        PcapDevice.Open(configuration);
    }

    public void Close()
    {
        PcapDevice.Close();
    }

    public void Dispose()
    {
        PcapDevice.Dispose();
    }
}
