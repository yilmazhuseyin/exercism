using System;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (input == "") return input;

        var result = String.Empty;
        int count = 0;
        char first = input[0];

        foreach (char item in input)
        {
            if (item == first) count++;

            else if (count == 1)
            {
                result += first.ToString();
                first = item;
            }
            else
            {
                result += count + first.ToString();
                count = 1;
                first = item;
            }
        }

        if (count != 1) result += count;

        result += first.ToString();

        return result;
    }

    public static string Decode(string input)
    {
        string digit = String.Empty;
        string result = String.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i])) digit += input[i].ToString();
            else
            {
                for (int k = 0; k < Convert.ToInt32(digit == String.Empty ? 1 : digit); k++) result += input[i].ToString();
                digit = String.Empty;
            }
        }
        return result;
    }
}
