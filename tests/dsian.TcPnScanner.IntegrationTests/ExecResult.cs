namespace dsian.TcPnScanner.IntegrationTests;

public record struct ExecResult
{
    public int ExitCode { get; init; }
    public string StdOut { get; init; }
    public string StdError { get; init; }
}
