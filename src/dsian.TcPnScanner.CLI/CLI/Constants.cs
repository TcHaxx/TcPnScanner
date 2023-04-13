namespace dsian.TcPnScanner.CLI;

/// <summary>
/// CLI constants.
/// </summary>
internal static class Constants
{
    /// <summary>
    /// Default console width.
    /// </summary>
    internal const int CLI_WIDTH = 100;

    internal const string TEMP_DIR_TEMPLATE = "%TEMP%";
    internal const string APPNAME_TEMPLATE = "$APPNAME$";
    internal const string TIMESTAMP_TEMPLATE = "yyyyMMddHHmmss";
    internal const string LOGFILE_DIRECTORY_DEFAULT = $"{TEMP_DIR_TEMPLATE}/{APPNAME_TEMPLATE}/{APPNAME_TEMPLATE}-.log";
    internal const string PCAP_DUMPFILE_DEFAULT = $"{TEMP_DIR_TEMPLATE}/{APPNAME_TEMPLATE}/{APPNAME_TEMPLATE}-{TIMESTAMP_TEMPLATE}.pcap";

    /// <summary>
    /// Exit codes for this application.
    /// </summary>
    internal enum ExitCodes : int
    {
        /// <summary>
        /// Exit code: No error.
        /// </summary>
        E_NOERROR = 0,

        /// <summary>
        /// Exit code: General exception occured.
        /// </summary>
        E_EXCEPTION = 1,

        /// <summary>
        /// Exit code: Parsing arguments and/or arguments missing/wrong.
        /// </summary>
        E_CLIOPTIONS = 10,
    }
}
