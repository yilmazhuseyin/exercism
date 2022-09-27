using System;
using System.Collections.Generic;
using System.Linq;
public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        var bests = new List<string>();
        var bestHand = Hands.HighCard;
        var bestRanks = new List<int>();

        foreach (string hand in hands)
        {
            (Hands curHandStrength, List<int> ranks) = GetHandStrength(hand);
            int compare = -1;

            if (bests.Count() == 0 || curHandStrength > bestHand) compare = 1;
            else if (bests.Count() > 0 && curHandStrength == bestHand)
            {
                compare = 0;
                for (int i = 0; i < ranks.Count() && compare == 0; i++) compare = ranks.ElementAt(i).CompareTo(bestRanks.ElementAt(i));             
            }
            if (compare > 0)
            {
                bestRanks = ranks;
                if (bests.Count() > 0) bests.Clear();
                if (curHandStrength > bestHand) bestHand = curHandStrength;
            }
            if (compare >= 0) bests.Add(hand);
        }
        return bests;
    }
    private static (Hands, List<int>) GetHandStrength(string hand)
    {
        IEnumerable<string> fiveCards = hand.Split(' ');
        IEnumerable<int> fiveRanks = fiveCards.Select(Rank).OrderByDescending(t => t);
        if (fiveRanks.SequenceEqual(new[] { 14, 5, 4, 3, 2 })) fiveRanks = new[] { 5, 4, 3, 2, 1 };

        bool flush = (fiveCards.Select(t => t[t.Length - 1]).Distinct().Count() == 1);
        bool straight = (fiveRanks.Distinct().Count() == 5 && fiveRanks.First() - fiveRanks.Last() == 4);
        Dictionary<int, int> rankMatches = straight ? new Dictionary<int, int> { [fiveRanks.First()] = 1 } : fiveRanks.GroupBy(t => t).OrderByDescending(t => t.Count()).ThenByDescending(t => t.Key).ToDictionary(t => t.Key, t => t.Count());
        if (straight && flush) return (Hands.StraightFlush, rankMatches.Select(t => t.Key).ToList());
        if (rankMatches.Any(t => t.Value == 4)) return (Hands.FourOfAKind, rankMatches.Select(t => t.Key).ToList());
        if (rankMatches.Count() == 2 && rankMatches.Any(t => t.Value == 3))  return (Hands.FullHouse, rankMatches.Select(t => t.Key).ToList());

        if (flush) return (Hands.Flush, rankMatches.Select(t => t.Key).ToList());
        if (straight) return (Hands.Straight, rankMatches.Select(t => t.Key).ToList());
        if (rankMatches.Any(t => t.Value == 3)) return (Hands.ThreeOfAKind, rankMatches.Select(t => t.Key).ToList());
        if (rankMatches.Count() == 3) return (Hands.TwoPair, rankMatches.Select(t => t.Key).ToList());
        if (rankMatches.Count() == 4) return (Hands.OnePair, rankMatches.Select(t => t.Key).ToList());

        return (Hands.HighCard, rankMatches.Select(t => t.Key).ToList());
    }
    private static int Rank(string card) => "__234567891JQKA".IndexOf(card[0]);
}
enum Hands
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush
}
