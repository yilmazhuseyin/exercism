using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    public Queue<T> Queue;
    private readonly int _capacity;

    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
        Queue = new Queue<T>(_capacity);
    }

    //Dequeue -> The object that is removed from the beginning of the Queue<T>.
    //Exceptions -> InvalidOperationException if the Queue<T> is empty.
    public T Read() => Queue.Dequeue();

    public void Write(T value)
    {
        if(Queue.Count >= _capacity) throw new InvalidOperationException();
        Queue.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (Queue.Count < _capacity) Queue.Enqueue(value);
        else
        {
            Queue.Dequeue();
            Queue.Enqueue(value);
        }
    }

    public void Clear() => Queue.Clear();
}
