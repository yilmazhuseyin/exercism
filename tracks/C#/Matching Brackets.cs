using System;
using System.Linq;
using System.Collections.Generic;

public static class MatchingBrackets
{
    public static bool IsPaired(string brackets)
    {
        int openIndex;
        int closeIndex;
        char open;

        Stack<char> stack = new Stack<char>();

        var openList = new List<char>() { '[', '{', '(' };
        var closeList = new List<char>() { ']', '}', ')'  };
       
        foreach (var item in brackets)
        {
            if (openList.Exists(x => x == item)) stack.Push(item);
            
            if (closeList.Exists(x => x == item))
            {
                if (stack.Count == 0) return false;

                open = stack.Pop();
                openIndex = openList.IndexOf(open);
                closeIndex = closeList.IndexOf(item);
                if (openIndex != closeIndex) return false; 
            }
        }

        return stack.Count == 0;
    }
}
