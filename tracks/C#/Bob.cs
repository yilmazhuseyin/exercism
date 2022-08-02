using System;

public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();
        bool allUpper = false;
        int upperCount = 0;
        int letterCount = 0;
        int statementLengt = statement.Length;

        foreach (var item in statement)
        {
            if (char.IsLetter(item) && char.IsUpper(item)) upperCount++;
            if (char.IsLetter(item)) letterCount++;
        }
        

        if (upperCount == letterCount && letterCount > 0) allUpper = true;
        
        if (!String.IsNullOrEmpty(statement))
        {
            if (statement[statement.Length - 1] == '?' && !allUpper)
                return "Sure.";
            else if (statement[statement.Length - 1] == '?' && allUpper)
                return "Calm down, I know what I'm doing!";
        }

        if (allUpper)
            return "Whoa, chill out!";
        else if (String.IsNullOrEmpty(statement))
            return "Fine. Be that way!";
        else
            return "Whatever.";
    }
}
