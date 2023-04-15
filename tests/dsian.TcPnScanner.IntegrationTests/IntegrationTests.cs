using dsian.TcPnScanner.IntegrationTests.Verify;
using System.Text.RegularExpressions;

namespace dsian.TcPnScanner.IntegrationTests;

public class IntegrationTests : VerifyBase
{
    private static string _sutExecutable = OperatingSystem.IsWindows() ? CLI.AssemblyHelper.Name + ".exe" : CLI.AssemblyHelper.Name;

    public IntegrationTests()
        : base()
    {
    }

    [Fact]
    public async Task Prints_Help()
    {
        var execResult = await Exec.ExecAsync(new(_sutExecutable), new string[] { "--help" });
        await Verify(execResult, VerifyGlobalSettings.GetGlobalSettings());
    }

    [Fact]
    public async Task Prints_Version()
    {
        var execResult = await Exec.ExecAsync(new(_sutExecutable), new string[] { "--version" });
        await Verify(execResult, VerifyGlobalSettings.GetGlobalSettings());
    }

    [Fact]
    public async Task Piping_No_Option_Fails()
    {
        var execResult = await Exec.ExecAsync(new(_sutExecutable));
        await Verify(execResult, VerifyGlobalSettings.GetGlobalSettings());
    }

    [Theory]
    [InlineData("-f")]
    [InlineData("--pcap-file")]
    public async Task Piping_Option_F_Parses_PcapFile_Successfully(string option)
    {
        var execResult = await Exec.ExecAsync(new(_sutExecutable), new string[] { option, "test-data/capture.pcap" });
        await Verify(execResult, VerifyGlobalSettings.GetGlobalSettings())
            .UseParameters(option);
    }
}
