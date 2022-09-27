using System;
public class Deque<T>
{
    private Element first;
    private Element last;
    public void Push(T value)
    {
        var formerLast = last;
        last = new Element { Value = value, Prev = formerLast };
        first ??= last;

        if (formerLast != null) formerLast.Next = last;
        
    }
    public T Pop()
    {
        var value = last.Value;
        last = last.Prev;
        return value;
    }
    public T Shift()
    {
        var value = first.Value;
        first = first.Next;
        return value;
    }
    public void Unshift(T value)
    {
        var previousFirst = first;
        first = new Element { Value = value, Next = previousFirst };
        last ??= first;
        if (previousFirst != null) previousFirst.Prev = first;
        
    }
    private class Element
    {
        public T Value { get; set; }
        public Element Next { get; set; }
        public Element Prev { get; set; }
    }
}
