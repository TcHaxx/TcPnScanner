using CommandLine;

namespace dsian.TcPnScanner.CLI;

/// <summary>
/// Parses command line arguments with <see cref="CommandLine.Parser"/>.
/// </summary>
internal static class ArgsParser
{
    internal static TOptions GetCommandLineOptionsOrExitOnError<TOptions>(string[] args)
    where TOptions : notnull, new()
    {
        var cmdLineOptions = ParseArguments<TOptions>(args);
        if (cmdLineOptions is null)
        {
            Environment.Exit((int)Constants.ExitCodes.E_CLIOPTIONS);
        }

        return cmdLineOptions;
    }

    private static TOptions? ParseArguments<TOptions>(string[] args)
        where TOptions : notnull, new()
    {
        TOptions? result = default;

        using var helpWriter = new StringWriter();
        using var parser = new Parser(with =>
        {
            with.HelpWriter = helpWriter;
            with.EnableDashDash = true;
            with.IgnoreUnknownArguments = false;
        });

        parser.ParseArguments<TOptions>(args)
            .WithParsed((o) => result = o)
            .WithNotParsed(errs => LogHelp(errs, helpWriter));

        return result;
    }



    private static void LogHelp(IEnumerable<Error> errs, TextWriter helpWriter)
    {
        if (errs.IsVersion() || errs.IsHelp())
        {
            Console.Write(helpWriter.ToString());
        }
        else
        {
            Console.Error.Write(helpWriter.ToString());
        }
    }
}
