namespace dsian.TcPnScanner.CLI.Export.TC;

internal class DefaultBoxVars
{
    internal static TcSmItemDeviceBoxVars[] GetDefaultVars()
    {

        return new TcSmItemDeviceBoxVars[2]
        {
            new TcSmItemDeviceBoxVars
            {
                Name = "Inputs",
                VarGrpType = 1,
                Var = new TcSmItemDeviceBoxVarsVar
                {
                    Name = "PnIoBoxState",
                    Comment = """
                        0x0001 = Device is in I/O exchange
                        0x0002 = Device is blinking
                        0x0004 = Provider State -> 0 = Stop, 1 = Run
                        0x0008 = Problem Indicator -> 0 = OK, 1 = Error
                        """,
                    Type = "UINT"
                }


            },
            new TcSmItemDeviceBoxVars
            {
                Name = "Outputs",
                VarGrpType = 2,
                Var = new TcSmItemDeviceBoxVarsVar
                {
                    Name = "PnIoBoxCtrl",
                    Comment = """
                        0x00XX = Last two hex characters of station name
                        """,
                    Type = "UINT"
                }
            }
        };
    }
}
