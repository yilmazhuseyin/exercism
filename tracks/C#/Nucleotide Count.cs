using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence) => sequence.All("ACGT".Contains) ? (sequence + "ACGT").GroupBy(x => x).ToDictionary(y => y.Key, y => y.Count() - 1) : throw new ArgumentException();
}
