namespace dsian.TcPnScanner.CLI.Export;

internal class TempDirectory
{
    internal static FileInfo CreateFileInfo(string exportFilePath, string controller = Constants.DEFAULT_CONTROLLER_NAME)
    {
        exportFilePath = exportFilePath.Replace(Constants.TEMP_DIR_TEMPLATE, Path.GetTempPath());
        exportFilePath = exportFilePath.Replace(Constants.APPNAME_TEMPLATE, AssemblyHelper.Name);
        exportFilePath = exportFilePath.Replace(Constants.CONTROLLER_FILENAME_TEMPLATE, controller);
        var exportDir = Path.GetDirectoryName(exportFilePath);
        if (!Directory.Exists(exportDir) && !string.IsNullOrEmpty(exportDir))
        {
            Directory.CreateDirectory(exportDir);
        }
        return new(exportFilePath);
    }
}
