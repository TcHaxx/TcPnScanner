using dsian.TcPnScanner.CLI.PnDevice;

namespace dsian.TcPnScanner.CLI.Export
{
    internal interface IExporter
    {
        MemoryStream Export(IEnumerable<Device> devices);
    }
}
