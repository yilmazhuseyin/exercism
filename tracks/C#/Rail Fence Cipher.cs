using System;
using System.Collections.Generic;
using System.Linq;
public class RailFenceCipher
{
    private readonly int _rails;
    public RailFenceCipher(int rails) => _rails = rails;

    public string Encode(string input)
    {
        var list = new string[_rails];
        int rail = 0;
        bool more = true;

        foreach (var item in input)
        {
            list[rail] += item.ToString();
            if (rail == 0) more = true;
            else if (rail == _rails - 1) more = false;
            if (more) rail++;
            else rail--;
        }

        return list.Aggregate("", (a, b) => a + b);
    }

    public string Decode(string input)
    {
        int first = 0;
        var rails = new List<string>();

        int[] listSub = new int[_rails];
        int final = 0;
        bool m = true;

        foreach (var c in input)
        {
            listSub[final] += 1;
            if (final == 0) m = true;
            else if (final == _rails - 1) m = false;
            if (m) final++;
            else final--;
        }

        foreach (var item in listSub)
        {
            rails.Add(input.Substring(first, item));
            first += item;
        }

        int[] secondRails = new int[_rails];
        string r = "";
        int rail = 0;
        bool more = true;

        for (int i = 0; i < input.Length; i++)
        {
            r += rails[rail][secondRails[rail]];
            secondRails[rail]++;
            if (rail == 0) more = true;
            else if (rail == _rails - 1) more = false;
            if (more) rail++;
            else rail--;
        }
        return r;
    }
}
