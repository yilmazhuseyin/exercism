using System;

public static class ScrabbleScore
{
    private static string onePoint = "AEIOULNRST";
    private static string twoPoint = "DG";
    private static string threePoint = "BCMP";
    private static string fourPoint = "FHVWY";
    private static string fivePoint = "K";
    private static string eightPoint = "JX";
    private static string tenPoint = "QZ";
    public static int Score(string input)
    {
        int score = 0;
        foreach (var letter in input.ToUpper())
        {
            if (onePoint.Contains(letter))
                score += 1;
            else if (twoPoint.Contains(letter))
                score += 2;
            else if (threePoint.Contains(letter))
                score += 3;
            else if (fourPoint.Contains(letter))
                score += 4;
            else if (fivePoint.Contains(letter))
                score += 5;
            else if (eightPoint.Contains(letter))
                score += 8;
            else if (tenPoint.Contains(letter))
                score += 10;
        }
        return score;
    }
}
