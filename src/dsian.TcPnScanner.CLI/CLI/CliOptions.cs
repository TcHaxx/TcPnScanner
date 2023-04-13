using CommandLine;
using Serilog.Events;

namespace dsian.TcPnScanner.CLI;

public sealed record CliOptions
{
    private const string SETNAME_CAP_DEVICE = "cap-device";
    private const string SETNAME_FILE_DEVICE = "pcap-file";

    [Option('d', "capture-device", Default = "", Required = false, HelpText = "The name of the capture device to use.", SetName = SETNAME_CAP_DEVICE)]
    public string CaptureDevice { get; init; } = string.Empty;

    [Option('t', "timeout", Default = 180u, Required = false, HelpText = "Capture timeout in seconds.", SetName = SETNAME_CAP_DEVICE)]
    public uint Timeout_s { get; init; }

    [Option('f', "pcap-file", Default = "", Required = false, HelpText = "Read from a pcap capture file.", SetName = SETNAME_FILE_DEVICE)]
    public string PcapFile { get; init; } = string.Empty;

    [Option('o', "out-xti-file", Default = Export.Constants.EXPORT_DIRECTORY_DEFAULT, HelpText = "Output directory to export the TwinCAT Export file.")]
    public string ExportDirectory { get; init; } = Export.Constants.EXPORT_DIRECTORY_DEFAULT;

    [Option('l', "log-level", Default = LogEventLevel.Information, HelpText = "Minimum LogEventLevel")]
    public LogEventLevel LogEventLevel { get; init; }

    [Option("log-file", Default = Constants.LOGFILE_DIRECTORY_DEFAULT, HelpText = "Path to logfile")]
    public string LogFile { get; init; } = Constants.LOGFILE_DIRECTORY_DEFAULT;

    [Option("dump", Default = false, HelpText = "Dump captured packets to file.")]
    public bool DumpPcap { get; init; }

    [Option("dump-file", Default = Constants.PCAP_DUMPFILE_DEFAULT, HelpText = "Pcap dump file.")]
    public string DumpPcapFile { get; init; } = Constants.PCAP_DUMPFILE_DEFAULT;
}

