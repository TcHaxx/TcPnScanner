using dsian.TcPnScanner.CLI.Packets;
using dsian.TcPnScanner.Tests.Verify;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;

namespace dsian.TcPnScanner.Tests
{
    public class ProfinetIoConnectRequestPacketTests : VerifyBase
    {
        const string PCAP_FILE = "test-data/pnio-cm.pcap";

        public ProfinetIoConnectRequestPacketTests()
            : base()
        {
        }

        [Fact]
        public async Task ShouldSuccessfullyParseAllPackets()
        {
            int index = 0;
            foreach (var packet in GetNextPacket())
            {
                Assert.True(ProfinetIoConnectRequestPacket.TryParse(packet, out var actual));
                await Verify(actual, VerifyGlobalSettings.GetGlobalSettings())
                    .AddExtraSettings((s) => s.Converters.Add(new JsonIpAddressConverter()))
                    .AddExtraSettings((s) => s.Converters.Add(new JsonPhysicalAddressConverter()))
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
                if (ethernetPacket.Type != EthernetType.IPv4)
                {
                    Assert.Fail($"Ethernet packet type IPv4 expected, but got {ethernetPacket.Type}");
                }
                yield return ethernetPacket;
            }
        }
    }
}
