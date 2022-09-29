using System;
public static class Wordy
{
    public static int Answer(string question)
    {
        var questions = question.Split(' ');

        if (questions[0] != "What" || questions[1] != "is" || questions[^1][^1] != '?' || (questions.Length < 5 && questions.Length != 3)) throw new ArgumentException();
        else if (questions.Length < 5) return int.Parse(questions[^1][0..^1]);

        var index = questions[4] == "by" ? 5 : 4;
        bool resa = int.TryParse(questions[2], out int a);
        bool resb = index == questions.Length - 1 ? int.TryParse(questions[index][0..^1], out int b) : int.TryParse(questions[index], out b);
        double output = 0D;

        if (resa && resb)
        {
            output = (questions[3]) switch
            {
                "plus" => a + b,
                "minus" => a - b,
                "multiplied" => a * b,
                "divided" => a / b,
                _ => a,
            };
        }
        else throw new ArgumentException();
        return index < questions.Length - 1 ? Answer($"What is {(int)output} " + string.Join(" ", questions[(index + 1)..])) : (int)output;
    }
}
