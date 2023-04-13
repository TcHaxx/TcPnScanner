using dsian.TcPnScanner.CLI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Constants = dsian.TcPnScanner.CLI.Constants;

var (_cliOptions, logger) = SetupCLI(args);

try
{
    var process = new Process(_cliOptions, logger);
    await process.Start();
}
catch (Exception ex)
{
    var critMsg = "❌ A critical error occurred!";

    logger?.LogCritical(ex, "{CriticalMessage}: {ExceptionMessage}", critMsg, ex.Message);

    if (logger is null || Console.IsOutputRedirected)
    {
        Console.Error.WriteLine(critMsg);
        Console.Error.WriteLine(ex.Message);
        Console.Error.WriteLine(ex.StackTrace);
    }
    Environment.Exit((int)Constants.ExitCodes.E_EXCEPTION);
}

return (int)Constants.ExitCodes.E_NOERROR;

static (CliOptions cliOptions, ILogger<Program>? logger) SetupCLI(string[] args)
{
    var cliOptions = ArgsParser.GetCommandLineOptionsOrExitOnError<CliOptions>(args);

    var logLevelSwitch = new LoggingLevelSwitch(cliOptions.LogEventLevel);
    var serviceProvider = ServiceProviderBuilder.BuildServiceProvider(logLevelSwitch, cliOptions);

    var logger = serviceProvider.GetService<ILogger<Program>>();

    return (cliOptions, logger);
}
