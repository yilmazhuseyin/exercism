using System;
using System.Linq;
using System.Collections.Generic;
public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        var mins = new List<int>();
        var currents = new List<int>();
        var forEach = new List<List<int>>();

        for (int i = 0; i <= target; i++)
        {
            forEach.Add(new List<int>());

            if (coins.Contains(i)) forEach[i].Add(i);
            
            else
            {
                for (int k = 0; k < coins.Length; k++)
                {
                    currents.Clear();
                    if (i > coins[k])
                    {
                        currents.Add(coins[k]);
                        currents.AddRange(forEach[i - coins[k]]);
                        if (currents.Sum() == i)
                        {
                            if (k == 0 || currents.Count() <= mins.Count())
                            {
                                mins.Clear();
                                mins.AddRange(currents);
                            }
                        }
                    }
                }
                forEach[i].AddRange(mins);
            }
        }
        if (target < 0 || forEach[target].Sum() != target) throw new ArgumentException();
        
        return forEach[target].OrderBy(n => n).ToArray();
    }
}
