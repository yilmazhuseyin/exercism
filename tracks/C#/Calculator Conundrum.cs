using System;

public static class SimpleCalculator
{
    public static string Calculate(int num1, int num2, string op) => op switch
    {
        "*" => $"{num1} {op} {num2} = {num1 * num2}",
        "+" => $"{num1} {op} {num2} = {num1 + num2}",
        "/" => num2 != 0 ? $"{num1} {op} {num2} = {num1 / num2}" : "Division by zero is not allowed.",
        "" => throw new ArgumentException(),
        null => throw new ArgumentNullException(),
        _ => throw new ArgumentOutOfRangeException()
    };
}
