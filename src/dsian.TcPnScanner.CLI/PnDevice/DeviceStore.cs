using dsian.TcPnScanner.CLI.Packets;
using PacketDotNet;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;

namespace dsian.TcPnScanner.CLI.PnDevice;

internal class DeviceStore : IDeviceStore
{
    public const int MAX_DEVICES_CAPACITY = 256;
    private readonly Dictionary<PhysicalAddress, Device> _devices = new Dictionary<PhysicalAddress, Device>(MAX_DEVICES_CAPACITY);

    public event EventHandler? OnAllDevicesScanned;

    public int Count => _devices.Count;

    public DeviceStore()
    {
    }

    public bool TryGetValue(PhysicalAddress key, [MaybeNullWhen(false)] out Device value)
    {
        return TryGetValue(key, out value);
    }

    public bool TryAddDevice(Device device)
    {
        var (phyAddr, foundDevice) = _devices.FirstOrDefault(x => x.Value.NameOfStation == device.NameOfStation);
        if (phyAddr is not null && _devices.ContainsKey(phyAddr))
        {
            _devices.Remove(phyAddr);
        }

        return _devices.TryAdd(device.PhysicalAddress, device);
    }

    public bool TryUpdateIpAddress(ProfinetDcpSetIPRequestPacket dcpSetIpReqPacket)
    {
        if (dcpSetIpReqPacket.SourcePacket is not EthernetPacket ethernetPacket)
        {
            return false;
        }
        if (!_devices.TryGetValue(ethernetPacket.DestinationHardwareAddress, out var device))
        {
            return false;
        }

        device.IpAddress = dcpSetIpReqPacket.IpAddress;
        return true;
    }

    public bool TryFindDevice(Func<Device, bool> predicate, [MaybeNullWhen(false)] out Device device)
    {
        device = _devices.Values.FirstOrDefault(predicate);
        return device is not null;
    }

    public bool UpdatePnIoConnectRequestPacket(ProfinetIoConnectRequestPacket profinetIoConnectRequestPacket)
    {
        var devicePhysicalAddress = _devices.Where(x => x.Value.IpAddress.Equals(profinetIoConnectRequestPacket.IPAddress))
                                    .Select(x => x.Key).FirstOrDefault();

        if (devicePhysicalAddress is null)
        {
            return false;
        }

        _devices[devicePhysicalAddress].PnIoConnectRequestPacket = profinetIoConnectRequestPacket;
        CheckIfAllDevicesHaveReceivedConReqPacket();
        return true;
    }

    public IEnumerable<Device> GetDevices()
    {
        return _devices.Values;
    }

    public string GetProfinetDeviceName()
    {
        var defaultName = "dsian.TcPnScanner (Profinet Device)";
        if (!_devices.Any())
        {
            return defaultName;
        }

        var pnIoConReqPacket = _devices.First().Value.PnIoConnectRequestPacket;
        if (pnIoConReqPacket is null)
        {
            return defaultName;
        }

        return $"{pnIoConReqPacket.ARBlockReqHeader.CMInitiatorStationName} (Profinet Device)";
    }

    private void CheckIfAllDevicesHaveReceivedConReqPacket()
    {
        if (!_devices.Any())
        {
            return;
        }

        var devicesWithConReqPacket = _devices.Values.Where(x => x.PnIoConnectRequestPacket is not null);
        if (devicesWithConReqPacket.Count() != _devices.Count)
        {
            return;
        }

        OnAllDevicesScanned?.Invoke(this, EventArgs.Empty);
    }
}
