using System;

public static class TwoFer
{
    public static string Speak(string name = "") => name switch
    {
        "" => "One for you, one for me.",
        _ => $"One for {name}, one for me."
    };
}
