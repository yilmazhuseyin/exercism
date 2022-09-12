using System;
using System.Linq;
using System.Collections.Generic;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        var result = new List<int>();

        if (outputBase < 2 || (inputBase < 2 || inputDigits.Any(x => (x < 0 || x >= inputBase)))) throw new ArgumentException();
        
        var bse = inputDigits.Reverse().Select((a, b) => a * (int)Math.Pow(inputBase, b)).Sum();

        while (bse >= outputBase)
        {
            result.Add(bse % outputBase);
            bse = bse / outputBase;
        }

        result.Add(bse % outputBase);

        result.Reverse();

        return result.ToArray();
    }

}
