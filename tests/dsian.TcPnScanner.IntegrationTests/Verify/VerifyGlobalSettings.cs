using Argon;
using System.Text.RegularExpressions;

namespace dsian.TcPnScanner.IntegrationTests.Verify;


public class VerifyGlobalSettings
{
    private static VerifySettings? _settings;

    private static readonly Func<string, bool> _scrubStackTraceLine = line => Regex.IsMatch(line, @"\s+at\s.*:line\s\d+$");
    private static readonly Func<string, string?> _scrubAppName = line => line.Replace(CLI.AssemblyHelper.Name, "$APPNAME$");
    private static readonly Func<string, string?> _scrubAppVersion = line => Regex.Replace(line, @"(dsian\.TcPnScanner\.CLI v?)\d+\.\d+\.\d+(\.\d+)?", "$1$TCPNSCANNER_VERSION$");
    private static readonly Func<string, string?> _scrubTcVersion = line => Regex.Replace(line, @"TcVersion=""\d+\.\d+\.\d+\.\d+""", @"TcVersion=""$TC_VERSION$""");
    private static readonly Func<string, string?> _scrubCopyRightYear = line => Regex.Replace(line, @"(Copyright \(c\) )\d{4}", @"$1$COPYRIGHTYEAR$");

    public static VerifySettings GetGlobalSettings()
    {
        return _settings ?? Instantiate();
    }

    private static VerifySettings Instantiate()
    {
        _settings = new VerifySettings();
        _settings.DontIgnoreEmptyCollections();
        _settings.UseDirectory("./Verify");
        _settings.AddExtraSettings((argon) =>
        {
            argon.Formatting = Formatting.Indented;
            argon.DefaultValueHandling = DefaultValueHandling.Include;
            argon.NullValueHandling = NullValueHandling.Include;
        });

        _settings.ScrubLines(_scrubStackTraceLine);
        _settings.ScrubLinesWithReplace(_scrubAppName);
        _settings.ScrubLinesWithReplace(_scrubAppVersion);
        _settings.ScrubLinesWithReplace(_scrubCopyRightYear);
        _settings.ScrubLinesWithReplace(_scrubTcVersion);

        return _settings;
    }

}
