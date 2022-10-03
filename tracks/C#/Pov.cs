using System;
using System.Collections.Generic;
using System.Linq;
#nullable enable
public class Tree
{
    public readonly string _value;
    public List<Tree> Children { get; private set; }
    public Tree? Parent { get; private set; }
    public Tree(string value, params Tree[] children)
    {
        _value = value;
        Children = new(children);
        foreach (var child in Children) child.Parent = this;
        Parent = null;
    }
    public Tree RecursiveFromPov(Tree? newParent = null)
    {
        Tree tree = new(_value, Children.ToArray());
        tree.Parent = Parent;
        if (tree.Parent is not null) tree.Children.Add(tree.Parent);
        if (newParent is not null) tree.Children.Remove(tree.Children.Find(child => child._value == newParent._value));
        List<Tree> newChildren = new();
        foreach (var child in tree.Children) newChildren.Add(child.RecursiveFromPov(tree));
        tree.Children = newChildren;
        tree.Parent = newParent;
        return tree;
    }
    public override bool Equals(object? other)
        => other is not null
        && other.GetType() == typeof(Tree)
        && Equals((Tree)other);
    public bool Equals(Tree other)
        => other._value == _value
        && Children.All(child => other.Children.Contains(child))
        && other.Children.All(child => Children.Contains(child));
}
public static class Pov
{
    public static Tree FromPov(Tree tree, string from)
    {
        Tree? newRoot = SearchTree(tree, from);
        if (newRoot is null)
            throw new ArgumentException($"node with _value {from} does not exist in the tree");
        return newRoot.RecursiveFromPov();
        
    }
    public static IEnumerable<string> PathTo(string from, string to, Tree tree)
    {
        Tree start = FromPov(tree, from);
        var potentialPath = RecursivePathFromRoot(start, to);
        return potentialPath is not null
            ? potentialPath
            : throw new ArgumentException($"node with _value {to} does not exist in the tree");
    }

    private static IEnumerable<string>? RecursivePathFromRoot(Tree start, string to)
    {
        foreach (var child in start.Children)
        {
            if (child._value == to)
            {
                return new List<string>() { start._value, child._value };
            }
            else
            {
                var potentialPath = RecursivePathFromRoot(child, to);
                if (potentialPath is not null)
                {
                    var result = new List<string>() { start._value };
                    result.AddRange(potentialPath);
                    return result;
                }
            }
        }
        return null;
    }
    private static Tree? SearchTree(Tree tree, string _value)
    {
        if (tree._value == _value)
            return tree;
        else
            foreach (var child in tree.Children)
                if (SearchTree(child, _value) is not null)
                    return SearchTree(child, _value);
        return null;
    }
}
