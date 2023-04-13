using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace dsian.TcPnScanner.CLI
{
    internal static class Guard
    {
        internal static void ThrowIfNull<T>([NotNull] T guardObj, [CallerArgumentExpression("guardObj")] string parameterName = "")
        {
            if (guardObj is null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
