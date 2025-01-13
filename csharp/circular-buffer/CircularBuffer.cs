using System;

public class CircularBuffer<T>(int capacity)
{
    private readonly T[] _buffer = new T[capacity];
    private int _indexFirst;
    private int _count;

    public T Read()
    {
        if (_count == 0)
            throw new InvalidOperationException("Buffer is empty.");

        var result = _buffer[_indexFirst];
        Clear();
        return result;
    }

    public void Write(T value)
    {
        if (_count == _buffer.Length)
            throw new InvalidOperationException("Buffer is full.");

        _buffer[(_indexFirst + _count) % _buffer.Length] = value;
        _count++;
    }

    public void Overwrite(T value)
    {
        if (_count < _buffer.Length)
        {
            Write(value);
            return;
        }

        _buffer[_indexFirst] = value;
        _indexFirst = (_indexFirst + 1) % _buffer.Length;
    }

    public void Clear()
    {
        if (_count <= 0)
        {
            return;
        }

        _indexFirst = (_indexFirst + 1) % _buffer.Length;
        _count--;
    }
}
