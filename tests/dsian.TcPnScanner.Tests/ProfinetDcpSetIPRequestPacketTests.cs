using dsian.TcPnScanner.CLI.Packets;
using dsian.TcPnScanner.Tests.Verify;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;

namespace dsian.TcPnScanner.Tests;

public class ProfinetDcpSetIPRequestPacketTests : VerifyBase
{
    const string PCAP_FILE = "test-data/pn-dcp.set-req.pcap";

    public ProfinetDcpSetIPRequestPacketTests()
        : base()
    {
    }

    [Fact]
    public async Task ShouldSuccessfullyParseAllPackets()
    {

        int index = 0;
        foreach (var packet in GetNextPacket())
        {
            Assert.True(ProfinetDcpSetIPRequestPacket.TryParse(packet, out var actual));
            await Verify(actual, VerifyGlobalSettings.GetGlobalSettings())
                .UseMethodName($"{nameof(ShouldSuccessfullyParseAllPackets)}_{index++}");
        }
    }


    private IEnumerable<Packet> GetNextPacket()
    {
        using var device = new CaptureFileReaderDevice(PCAP_FILE);
        device.Open();

        while (device.GetNextPacket(out var e) == SharpPcap.GetPacketStatus.PacketRead)
        {

            var rawPacket = e.GetPacket();


            if (rawPacket.LinkLayerType != LinkLayers.Ethernet)
            {
                Assert.Fail($"LinkLayerType Ethernet expected, but got {rawPacket.LinkLayerType}");
            }
            var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            var ethernetPacket = (EthernetPacket)packet;
            if (ethernetPacket.PayloadPacket is null)
            {
                Assert.Fail("No PayloadPacket or type is not Profinet");
            }
            if (ethernetPacket.Type != EthernetType.VLanTaggedFrame)
            {
                Assert.Fail($"Ethernet packet type VLanTaggedFrame expected, but got {ethernetPacket.Type}");
            }
            yield return ethernetPacket;
        }
    }
}
