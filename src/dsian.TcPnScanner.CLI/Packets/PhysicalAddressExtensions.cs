using System.Net.NetworkInformation;

namespace dsian.TcPnScanner.CLI.Packets
{
    internal static class PhysicalAddressExtensions
    {
        internal static PhysicalAddress CreateFakePhysicalAddress(uint xid)
        {
            var fakeAddress = new byte[6] { 0xbe, 0xef, 0x0, 0x0, 0x0, 0x0 };
            BitConverter.GetBytes(xid).CopyTo(fakeAddress, 2);
            return new PhysicalAddress(fakeAddress);
        }
    }
}
