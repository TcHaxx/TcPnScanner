using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dsian.TcPnScanner.CLI.Packets;

internal class MarshalAs
{
    internal static bool TryDeserializeStruct<TStruct>(ReadOnlySpan<byte> raw, [NotNullWhen(true)] out TStruct deserializedStruct)
        where TStruct : struct
    {
        deserializedStruct = default;
        IntPtr ptr = IntPtr.Zero;
        try
        {

            ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TStruct)));
            Marshal.Copy(raw.ToArray(), 0, ptr, Marshal.SizeOf(typeof(TStruct)));
            var ptr2Struct = Marshal.PtrToStructure(ptr, typeof(TStruct));
            if (ptr2Struct is not null)
            {
                deserializedStruct = (TStruct)ptr2Struct;
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }
    }
}
