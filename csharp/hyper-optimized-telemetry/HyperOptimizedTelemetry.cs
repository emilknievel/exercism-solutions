using System;
using System.Collections.Generic;
using System.Linq;

public static class TelemetryBuffer
{
    private const int PrefixBase = 256;

    public static byte[] ToBuffer(long reading)
    {

        var bytes = reading switch
        {
            < int.MinValue => BitConverter.GetBytes(reading).Prepend((byte)(PrefixBase - 8)),
            < short.MinValue => BitConverter.GetBytes((int)reading).Prepend((byte)(PrefixBase - 4)),
            < ushort.MinValue => BitConverter.GetBytes((short)reading).Prepend((byte)(PrefixBase - 2)),
            <= ushort.MaxValue => BitConverter.GetBytes((ushort)reading).Prepend((byte)2),
            <= int.MaxValue => BitConverter.GetBytes((int)reading).Prepend((byte)(PrefixBase - 4)),
            <= uint.MaxValue => BitConverter.GetBytes((uint)reading).Prepend((byte)4),
            _ => BitConverter.GetBytes(reading).Prepend((byte)(PrefixBase - 8))
        };

        var bytesList = bytes.ToList();
        return bytesList.Concat(new byte[9 - bytesList.Count()]).ToArray();
    }

    public static long FromBuffer(byte[] buffer) => buffer[0] switch
    {
        PrefixBase - 8 or 4 or 2 => BitConverter.ToInt64(buffer, 1),
        PrefixBase - 4 => BitConverter.ToInt32(buffer, 1),
        PrefixBase - 2 => BitConverter.ToInt16(buffer, 1),
        _ => 0
    };
}
