using System;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var result = String.Empty;

        foreach (var c in phoneNumber) if (Char.IsDigit(c)) result += c;

        result = result[0] == '1' ? result.Remove(0, 1) : result;

        return result.Length == 10 && result[0] - '0' > 1 && result[3] - '0' > 1 ? result : throw new ArgumentException();
    }
}
