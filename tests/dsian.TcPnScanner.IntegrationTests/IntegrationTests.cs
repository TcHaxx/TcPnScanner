using dsian.TcPnScanner.IntegrationTests.Verify;

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
        var tmpFile = Path.Join(Path.GetTempPath(), CLI.AssemblyHelper.Name, nameof(Piping_Option_F_Parses_PcapFile_Successfully) + Environment.Version + ".xti");
        var execResult = await Exec.ExecAsync(new(_sutExecutable), new string[] { option, "test-data/capture.pcap", "-o", tmpFile });
        await Verify(execResult, VerifyGlobalSettings.GetGlobalSettings())
            .UseParameters(option);
        File.Delete(tmpFile);
    }

    [Theory]
    [InlineData("-o")]
    [InlineData("--out-xti-file")]
    public async Task Option_O_Exports_XTI_Successfully(string option)
    {
        var tmpFile = Path.Join(Path.GetTempPath(), CLI.AssemblyHelper.Name, nameof(Option_O_Exports_XTI_Successfully) + Environment.Version + ".xti");
        var execResult = await Exec.ExecAsync(new(_sutExecutable), new string[] { "-f", "test-data/capture.pcap", option, tmpFile });
        Assert.True(File.Exists(tmpFile));
        await VerifyFile(tmpFile, VerifyGlobalSettings.GetGlobalSettings())
            .UseParameters(option);
        File.Delete(tmpFile);
    }
}
