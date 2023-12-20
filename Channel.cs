using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

public interface IWriteChannel<T> : IDisposable
{
    void Write(T value);
}

public interface IReadChannel<T> : IDisposable, IEnumerable<T>
{
    T Read();
}

public interface IChannel<T> : IWriteChannel<T>, IReadChannel<T>
{
}

public class Channel<T> : IChannel<T>
{
    readonly BlockingCollection<T> queue = [];

    public void Write(T value)
    {
        queue.Add(value);
    }

    public T Read()
    {
        return queue.Take();
    }

    void IDisposable.Dispose()
    {
        queue.CompleteAdding();
        queue.Dispose();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return queue.GetConsumingEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
