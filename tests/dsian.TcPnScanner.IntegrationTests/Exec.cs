using System.Diagnostics;

namespace dsian.TcPnScanner.IntegrationTests;

internal static class Exec
{
    internal static async Task<ExecResult?> ExecAsync(FileInfo executable, string[]? args = null)
    {
        if (!executable.Exists)
        {
            throw new FileNotFoundException("File not found", executable.FullName);
        }

        return await Task.Run(() =>
        {
            return SpawnProcess(executable.FullName, args);
        });
    }

    private static ExecResult? SpawnProcess(string executable, string[]? args = null)
    {
        using var process = new Process();
        process.StartInfo.FileName = executable;
        if (args is not null && args.Any())
        {
            process.StartInfo.Arguments = string.Join(" ", args);
        }

        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
        process.StartInfo.StandardErrorEncoding = System.Text.Encoding.UTF8;
        process.Start();
        var stdOutput = process.StandardOutput.ReadToEnd();
        var stdError = process.StandardError.ReadToEnd();
#if NET7_0_OR_GREATER
        process.WaitForExit(TimeSpan.FromSeconds(300));
#else
        process.WaitForExit(300_000);
#endif

        return new ExecResult
        {
            ExitCode = process.ExitCode,
            StdError = stdError,
            StdOut = stdOutput
        };
    }
}
