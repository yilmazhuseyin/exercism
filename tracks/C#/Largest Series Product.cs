using System;
using System.Linq;
public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        var result = 0;
        
        if (span == 0) return 1;

        if (span > digits.Length || span < 0 || digits == String.Empty || new string(digits.Where(x => char.IsDigit(x)).ToArray()) != digits) throw new ArgumentException();
        
        for (int i = 0; i <= digits.Length - span; i++)
        {
            int count = 1;

            int[] list = digits.Substring(i, span).Select(x => (int)char.GetNumericValue(x)).ToArray();

            foreach (int number in list) count *= number;
            
            if (count >= result) result = count;
        }
        return result;
    }
}
