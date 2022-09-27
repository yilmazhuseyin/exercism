using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class SimpleLinkedList<T> : IEnumerable<T>
{
    private IEnumerable<T> list;
    private int index;

    public SimpleLinkedList(T value)
    {
        list = new List<T> { value };
        index = 0;
    }
    public SimpleLinkedList(IEnumerable<T> values)
    {
        list = new List<T>(values);
        index = 0;
    }
    public T Value
    {
        get => list.ElementAt(index);
        
    }
    public SimpleLinkedList<T> Next
    {
        get
        {
            if (list.Count() > index + 1)
            {
                var next = new SimpleLinkedList<T>(list);
                next.index = index + 1;
                return next;
            }
            return null;
        }
    }
    public SimpleLinkedList<T> Add(T value) => new SimpleLinkedList<T>(list.Append(value));
        
    public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    
}
