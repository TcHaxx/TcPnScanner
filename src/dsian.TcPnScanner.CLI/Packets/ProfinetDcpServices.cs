namespace dsian.TcPnScanner.CLI.Packets;


enum PnDcpServiceId : byte
{
    Reserved = 0x0,
    ManufacturerSpecific1 = 0x1,
    ManufacturerSpecific2 = 0x2,
    Get = 0x3,
    Set = 0x4,
    Identify = 0x5,
    Hello = 0x6

}

enum PnDcpServiceType : byte
{
    Request = 0x0,
    ResponseSuccess = 0x1,
    ResponseUnsupported = 0x5,
}
