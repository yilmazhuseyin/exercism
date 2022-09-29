using System;
using System.Collections.Generic;
using System.Linq;
public static class Forth
{
    public static string Evaluate(string[] instructions)
    {
        var tokens = GetItems(instructions);
        var values = new Stack<int>();
        foreach (var token in tokens)
        {
            if (token == "+")
                Binary(values, (x1, x2) => new[] { x1 + x2 });
            else if (token == "-")
                Binary(values, (x1, x2) => new[] { x1 - x2 });
            else if (token == "*")
                Binary(values, (x1, x2) => new[] { x1 * x2 });
            else if (token == "/")
                Binary(values, (x1, x2) => x2 == 0 ? throw new DivideByZeroException() : new[] { x1 / x2 });
            else if (token[0] == '-' || '0' <= token[0] && token[0] <= '9')
                values.Push(int.Parse(token));
            else if (token.Equals("dup", StringComparison.OrdinalIgnoreCase))
                Unary(values, (x1) => new[] { x1, x1 });
            else if (token.Equals("drop", StringComparison.OrdinalIgnoreCase))
                Unary(values, (x1) => new int[0]);
            else if (token.Equals("over", StringComparison.OrdinalIgnoreCase))
                Binary(values, (x1, x2) => new[] { x1, x2, x1 });
            else if (token.Equals("swap", StringComparison.OrdinalIgnoreCase))
                Binary(values, (x1, x2) => new[] { x2, x1 });
            else
                throw new InvalidOperationException();
        }
        return string.Join(" ", values.Reverse());
    }
    static IEnumerable<string> GetItems(string[] instructions)
    {
        var dic = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

        foreach (var item in instructions)
        {
            var tokens = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var subToken in GetItems(tokens, dic)) yield return subToken;
        }
    }

    static IEnumerable<string> GetItems(string[] items, Dictionary<string, string[]> macros)
    {
        if (items.Length > 0)
        {
            if (items[0] == ":")
            {
                if (items.Length < 4) throw new InvalidOperationException();
                var key = items[1];
                if ('0' <= key[0] && key[0] <= '9') throw new InvalidOperationException();
                var body = items.AsSpan(2, items.Length - 3).ToArray();
                macros[key] = GetItems(body, macros).ToArray();
            }
            else foreach (var token in items)
                {
                    if (macros.TryGetValue(token, out string[] body))
                    {
                        foreach (var subToken in body)
                        {
                            yield return subToken;
                        }
                    }
                    else if (
                        token == "+"
                        || token == "-"
                        || token == "*"
                        || token == "/"
                        || (token[0] == '-' || '0' <= token[0] && token[0] <= '9')
                        || token.Equals("dup", StringComparison.OrdinalIgnoreCase)
                        || token.Equals("drop", StringComparison.OrdinalIgnoreCase)
                        || token.Equals("over", StringComparison.OrdinalIgnoreCase)
                        || token.Equals("swap", StringComparison.OrdinalIgnoreCase)
                    )
                    {
                        yield return token;
                    }
                    else throw new InvalidOperationException();
                }
        }
    }
    static void Unary(Stack<int> stack, Func<int, IEnumerable<int>> oper)
    {
        if (!stack.TryPop(out int x1)) throw new InvalidOperationException();
        foreach (var value in oper(x1))
        {
            stack.Push(value);
        }
    }
    static void Binary(Stack<int> stack, Func<int, int, IEnumerable<int>> oper)
    {
        if (!stack.TryPop(out int x2)) throw new InvalidOperationException();
        if (!stack.TryPop(out int x1)) throw new InvalidOperationException();
        foreach (var value in oper(x1, x2))
        {
            stack.Push(value);
        }
    }
}
