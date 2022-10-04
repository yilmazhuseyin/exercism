using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Sprache;
public static class Alphametics
{
    public static IDictionary<char, int> Solve(string equation)
    {
        var letters = Regex.Replace(equation, "[^A-Z]", "").Distinct();
        var permutations = Calc(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, letters.Count());
        foreach (var item in permutations)
        {
            var solution = letters
                .Zip(item, (key, value) => new { key, value })
                .ToDictionary(valPair => valPair.key, valPair => valPair.value);
            if (solution[equation.Split(" == ")[1][0]] == 0 || equation.Split(" == ")[0].Split(" + ").Any(term => solution[term[0]] == 0))
                continue;
            if (isSolution(solution, equation.Split(" == ")[0].Split(" + "), equation.Split(" == ")[1]))
                return solution;
        }
        throw new ArgumentException();
    }
    private static IEnumerable<IEnumerable<int>> Calc(IEnumerable<int> list, int length)
    {
        if (length == 1) return list.Select(i => new[] { i });
        return Calc(list, length - 1).SelectMany(permutation => list.Where(el => !permutation.Contains(el)),
            (first, second) => first.Concat(new[] { second }));
    }
    private static long ConvertTerm(IDictionary<char, int> solution, string term)
        => long.Parse(string.Concat(term.Select(c => solution[c])));
    private static bool isSolution(IDictionary<char, int> solution, string[] terms, string eqSum)
        => terms.Select(term => ConvertTerm(solution, term)).Sum() == ConvertTerm(solution, eqSum);
}
