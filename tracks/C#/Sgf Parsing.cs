using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using Sprache;

public class SgfTree
{
    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }
    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }
}
public class SgfParser
{
    public static SgfTree ParseTree(string input)
    {
        var result = TreeParser.TryParse(input);
        return result.WasSuccessful ? result.Value : throw new ArgumentException();
    }
    private static readonly Parser<SgfTree> TreeParser = Parse.Char('(')
        .SelectMany(_ => NodeParser, (_, sgfTree) => sgfTree)
        .SelectMany(_ => Parse.Char(')'), (t, _) => t);
    private static readonly Parser<SgfTree> NodeParser = Parse.Char(';')
        .SelectMany(_ => AttributeParser.Many(), (_, attributes) => attributes)
        .SelectMany(_ => NodeParser.Once().Or(TreeParser.Many()),
            (t, children) => new SgfTree(t.ToDictionary(o => o.Item1, o => o.Item2), children.ToArray()));
    private static readonly Parser<(string, string[])> AttributeParser = Parse.Upper
        .Many()
        .Text()
        .SelectMany(_ => AttributeValueParser.AtLeastOnce(), (name, values) => (name, values.ToArray()));
    private static readonly Parser<string> AttributeValueParser =
        Parse.Char('[').SelectMany(_ => ValidPropValuesParser.Until(Parse.Char(']')).Text(), (_, y) => y);
    private static readonly Parser<char> ValidPropValuesParser =
        Parse.String("\\n").Return('\n')
            .Or(Parse.String("\\t").Return(' '))
            .Or(Parse.Char('\\').Then(_ => Parse.AnyChar))
            .Or(Parse.WhiteSpace)
            .Or(Parse.Letter);
}
