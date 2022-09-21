using System.Collections.Generic;
public class BinarySearchTree
{
    public int Value { get; private set; }
    public BinarySearchTree Left { get; private set; }
    public BinarySearchTree Right { get; private set; }

    public BinarySearchTree(int value) => Value = value;
    
    public BinarySearchTree(int[] values)
    {
        Value = values[0];
        for (int i = 1; i < values.Length; i++) Add(values[i]);
    }

    public BinarySearchTree Add(int value)
    {
        if (Value >= value)
        {
            if (Left != null) Left.Add(value);
            else Left = new BinarySearchTree(value);
        }
        else
        {
            if (Right != null) Right.Add(value);
            else Right = new BinarySearchTree(value);
        }

        return this;
    }

    public IEnumerable<int> AsEnumerable()
    {
        if (Left != null) foreach (var value in Left.AsEnumerable()) yield return value;            
        
        yield return Value;

        if (Right != null) foreach (var value in Right.AsEnumerable()) yield return value;
        
    }
}
