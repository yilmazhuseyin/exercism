using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    public static Dictionary<int, decimal> priceDictionary = new(){{1, 8m},{2, 15.2m},{3, 21.6m},{4, 25.6m},{5, 30m}};
    public static decimal Total(IEnumerable<int> books)
    {
        Dictionary<int, int> firstNum = new();

        books.ToList().ForEach(x =>
        {
            if (!firstNum.ContainsKey(x)) firstNum.Add(x, 1);
            else firstNum[x] += 1;
        });

        decimal sum = decimal.MaxValue;
        var firstGroup = 5;
        int i = 5;

        while (i > 0)
        {
            var group = firstGroup--;
            decimal k = 0;
            Dictionary<int, int> map = new(firstNum);
            var y = 5;

            while (y > 0)
            {
                while (map.Count >= group)
                {
                    k += priceDictionary[group];
                    Reduc(map, group);
                }

                y--;
                group--;

                if (group == 0) group = 5;
            }

            sum = Math.Min(sum, k);
            i--;
        }
        return sum;
    }

    private static void Reduc(Dictionary<int, int> map, int group)
    {
        map.OrderByDescending(x => x.Value).ToList().ForEach(x =>
        {
            if (group > 0 && map[x.Key] > 0)
            {
                map[x.Key] -= 1;
                group--;
            }
        });

        for (int i = 1; i < 6; i++) if (map.ContainsKey(i)) if (map[i] == 0) map.Remove(i);
    }
}
