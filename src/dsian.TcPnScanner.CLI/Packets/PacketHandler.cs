using dsian.TcPnScanner.CLI.PnDevice;
using Microsoft.Extensions.Logging;
using PacketDotNet;
using System.Text;

namespace dsian.TcPnScanner.CLI.Packets;

internal class PacketHandler : IPacketHandler
{
    private readonly ICaptureDeviceProxy _captureDevice;
    private readonly IDeviceStore _deviceStore;
    private readonly ILogger? _logger;

    public PacketHandler(ICaptureDeviceProxy captureDevice, IDeviceStore deviceStore, ILogger? logger = default)
    {
        Guard.ThrowIfNull(captureDevice);
        _captureDevice = captureDevice;
        Guard.ThrowIfNull(deviceStore);
        _deviceStore = deviceStore;
        _deviceStore.OnAllDevicesScanned += DeviceStore_OnAllDevicesScanned;
        _logger = logger;
        _logger?.BeginScope(this);
    }

    public void HandleEthernetPacket(EthernetPacket ethPacket)
    {
        try
        {
            if (ProfinetDcpIdentRequestPacket.TryParse(ethPacket, out var pnIdentPacket, _logger))
            {
                _deviceStore.TryAddDevice(DeviceFactory.CreateFromPacket(pnIdentPacket));

                SendProfinetDcpIdentResponsePacket(pnIdentPacket);
            }
            else if (ProfinetDcpSetIPRequestPacket.TryParse(ethPacket, out var pnSetIpPacket))
            {
                _deviceStore.TryUpdateIpAddress(pnSetIpPacket);

                SendProfinetDcpSetIpResponsePacket(pnSetIpPacket);
            }
            else if (ethPacket.Type == EthernetType.Arp)
            {
                SendArpResponsePacket(ethPacket);
            }
            else if (ethPacket.Type == EthernetType.Lldp)
            {
            }
            else if (ProfinetIoConnectRequestPacket.TryParse(ethPacket, out var pnIoConReqPacket, _logger))
            {
                UpdateDevicePnIoConReqPacket(pnIoConReqPacket);
            }
            else
            {
                _logger?.LogWarning("Ignoring packet: {EthernetPacket}", ethPacket);
                return;
            }
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error occured on packet {EthernetPacket}", ethPacket);
        }
    }

    private void UpdateDevicePnIoConReqPacket(ProfinetIoConnectRequestPacket pnIoConReqPacket)
    {
        if (!_deviceStore.UpdatePnIoConnectRequestPacket(pnIoConReqPacket))
        {
            _logger?.LogWarning("Couldn't find matching device for {PnIoConReqPacket}", pnIoConReqPacket);
            return;
        }
    }

    private void SendProfinetDcpIdentResponsePacket(ProfinetDcpIdentRequestPacket pnPacket)
    {

        var ethPacket = (EthernetPacket)pnPacket.SourcePacket!;
        var responsePacket = new EthernetPacket(pnPacket.FakePhysicalAddress, ethPacket.SourceHardwareAddress, EthernetType.Profinet);
        var data = new List<byte>();
        data.AddRange(BitConverter.GetBytes(ProfinetDcpIdentRequestPacket.FRAME_ID_RES).Reverse());
        data.Add((byte)PnDcpServiceId.Identify);
        data.Add((byte)PnDcpServiceType.ResponseSuccess);
        data.AddRange(BitConverter.GetBytes(pnPacket.Xid));
        data.Add(0x0);
        data.Add(0x0);

        var blockDevName = BlockDeviceNameOfStation(pnPacket).Reverse().ToArray();
        var blockId = BlockIpNotSet();

        data.AddRange(BitConverter.GetBytes(((ushort)(blockDevName.Length + blockId.Length))).Reverse());

        data.AddRange(blockDevName);
        data.AddRange(blockId);

        responsePacket.PayloadData = data.ToArray();
        _captureDevice.SendPacketHandler(responsePacket);
    }

    private byte[] BlockDeviceNameOfStation(ProfinetDcpIdentRequestPacket pnPacket)
    {
        var data = new List<byte>();
        data.Add(0x2);  // Option: DeviceProperties
        data.Add(0x2);  // Suboption: Name of Station
        var lenName = pnPacket.NameOfStation.Length;
        data.AddRange(BitConverter.GetBytes((ushort)(lenName + 2)).Reverse()); // DcpBlockLength
        data.AddRange(BitConverter.GetBytes((ushort)0x0)); //reserved
        data.AddRange(Encoding.UTF8.GetBytes(pnPacket.NameOfStation));
        if (pnPacket.NameOfStation.Length % 2 != 0)
        {
            data.Add(0x0);      // Padding-byte if odd length
        }
        data.Reverse();
        return data.ToArray();
    }

    private byte[] BlockIpNotSet()
    {
        var data = new List<byte>();
        data.Add(0x1);  // Option: IP
        data.Add(0x2);  // Suboption: IP Parameter
        data.AddRange(BitConverter.GetBytes((ushort)(14)).Reverse()); // DcpBlockLength
        data.AddRange(Enumerable.Repeat<byte>(0x0, 14));
        return data.ToArray();
    }

    private void SendProfinetDcpSetIpResponsePacket(ProfinetDcpSetIPRequestPacket pnPacket)
    {
        var ethPacket = (EthernetPacket)pnPacket.SourcePacket!;
        var responsePacket = new EthernetPacket(ethPacket.DestinationHardwareAddress, ethPacket.SourceHardwareAddress, EthernetType.Profinet);
        var data = new List<byte>();
        data.AddRange(BitConverter.GetBytes(ProfinetDcpSetIPRequestPacket.FRAME_ID_RES).Reverse());
        data.Add((byte)PnDcpServiceId.Set);
        data.Add((byte)PnDcpServiceType.ResponseSuccess);
        data.AddRange(BitConverter.GetBytes(pnPacket.Xid));
        data.Add(0x0);
        data.Add(0x0);

        data.Add(0x0);
        data.Add(0x8);  // DcpDataLength

        data.Add(0x5);  // Option: Control
        data.Add(0x4);  // Suboption: Response
        data.Add(0x0);
        data.Add(0x3);  // DcpBlockLength
        data.Add(0x1);  // Option: IP
        data.Add(0x2);  // Suboption: IP Parameter
        data.Add(0x0);  // BlockError

        data.Add(0x0);  // Padding 1 Byte

        responsePacket.PayloadData = data.ToArray();
        _captureDevice.SendPacketHandler(responsePacket);
    }

    private void SendArpResponsePacket(EthernetPacket ethPacket)
    {
        var arpPacket = (ArpPacket)ethPacket.PayloadPacket;

        if (!_deviceStore.TryFindDevice(x => x.IpAddress.Equals(arpPacket.TargetProtocolAddress), out var foundDevice))
        {
            return;
        }

        var responsePacket = new EthernetPacket(foundDevice.PhysicalAddress, ethPacket.SourceHardwareAddress, EthernetType.Arp);

        var data = new List<byte>();

        data.AddRange(BitConverter.GetBytes((ushort)1).Reverse());  // HW Type: Ethernet
        data.AddRange(BitConverter.GetBytes((ushort)0x800).Reverse());  // Prtocol Type: IPv4
        data.Add(0x6);  // HW Size: 6
        data.Add(0x4);  // Protocol Size: 4
        data.AddRange(BitConverter.GetBytes((ushort)2).Reverse());  // Opcode: reply
        data.AddRange(foundDevice.PhysicalAddress.GetAddressBytes());
        data.AddRange(arpPacket.TargetProtocolAddress.GetAddressBytes());
        data.AddRange(arpPacket.SenderHardwareAddress.GetAddressBytes());
        data.AddRange(arpPacket.SenderProtocolAddress.GetAddressBytes());

        responsePacket.PayloadData = data.ToArray();
        _captureDevice.SendPacketHandler(responsePacket);
    }
    private void DeviceStore_OnAllDevicesScanned(object? sender, EventArgs e)
    {
        _captureDevice.PcapDevice.StopCapture();
        _logger?.LogInformation("✨ Successfully scanned {NumberOfScannedDevices} device(s)!", _deviceStore.Count);
    }
}
