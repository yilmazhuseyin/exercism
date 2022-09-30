using System;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category) => category switch
    {
        _ when (int)category <= 6 => dice.Where(d => d == (int)category).Sum(),
        YachtCategory.FullHouse => dice.IsFullHouse() ? dice.Sum() : 0,
        YachtCategory.FourOfAKind => dice.IsFourOfAKind() ? dice.GroupBy(d => d).OrderBy(group => group.Count()).Last().First() * 4 : 0,
        YachtCategory.LittleStraight => dice.IsStraight(_littleStraight) ? 30 : 0,
        YachtCategory.BigStraight => dice.IsStraight(_bigStraight) ? 30 : 0,
        YachtCategory.Choice => dice.Sum(),
        YachtCategory.Yacht => dice.IsYacht() ? 50 : 0
    };

    private static bool IsFullHouse(this int[] dice) => dice.GroupBy(d => d).Count() == 2 && dice.GroupBy(d => d).OrderBy(group => group.Count()).Last().Count() == 3;
    
    private static bool IsFourOfAKind(this int[] dice) => dice.GroupBy(d => d).First().Count() >= 4;
    private static int[] _littleStraight = { 1, 2, 3, 4, 5 };
    private static int[] _bigStraight = { 2, 3, 4, 5, 6 };
    private static bool IsStraight(this int[] dice, int[] straight) => dice.Intersect(straight).Count() == 5;
    private static bool IsYacht(this int[] dice) => dice.GroupBy(d => d).Count() == 1;
}
