using System.Reflection;
using System.Text;

namespace dsian.TcPnScanner.CLI;

/// <summary>
/// CLI Helper and Extension Methods.
/// </summary>
internal static class Helper
{
    /// <summary>
    /// Centers a string.
    /// </summary>
    internal static string Center(this string @this, int length = Constants.CLI_WIDTH)
    {
        if (string.IsNullOrEmpty(@this))
        {
            return string.Empty;
        }

        return @this.PadLeft(((length - @this.Length) / 2)
                              + @this.Length)
                              .PadRight(length);
    }
}
