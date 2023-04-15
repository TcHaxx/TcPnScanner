namespace dsian.TcPnScanner.CLI.Export;

internal static class Constants
{
    internal const string TEMP_DIR_TEMPLATE = "%TEMP%";
    internal const string CONTROLLER_FILENAME_TEMPLATE = "$CONTROLLER$";
    internal const string APPNAME_TEMPLATE = "$APPNAME$";
    internal const string DEFAULT_CONTROLLER_NAME = "dsian.TcPnScanner";
    internal const string EXPORT_DIRECTORY_DEFAULT = $"{TEMP_DIR_TEMPLATE}/{APPNAME_TEMPLATE}/{CONTROLLER_FILENAME_TEMPLATE}.xti";
}
