using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffs = new byte[9];
        byte[] bytes = BitConverter.GetBytes(reading);

        buffs[0] = reading switch
        {
            >= int.MinValue and < short.MinValue => 256 - 4,
            >= short.MinValue and < 0 => 256 - 2,
            >= 0 and <= ushort.MaxValue => 2,
            > ushort.MaxValue and <= int.MaxValue => 256 - 4,
            > int.MinValue and <= uint.MaxValue => 4,
            _ => 256 - 8
        };
        int prefix = Math.Abs((buffs[0] < 8) ? buffs[0] : buffs[0] - 256);
        Array.Copy(bytes, 0, buffs, 1, prefix);
        return buffs;
    }
    public static long FromBuffer(byte[] buffer)
    {
        int first = buffer[0];
        switch (first)
        {
            case 248: return BitConverter.ToInt64(buffer, 1);
            case 252: return BitConverter.ToInt32(buffer, 1);
            case 254: return BitConverter.ToInt16(buffer, 1);
            case 002: return BitConverter.ToUInt16(buffer, 1);
            case 004: return BitConverter.ToUInt32(buffer, 1);
            default: return 0;
        }
    }
}
