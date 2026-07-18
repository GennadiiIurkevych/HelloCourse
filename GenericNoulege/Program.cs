
using System.Collections.ObjectModel;

public class LimitedCache<TKey, TValue> where TKey : notnull
{
    private readonly int _capacity;
    private readonly Dictionary<TKey, TValue> _values = new();
    private readonly Queue<TKey> _evictionOrder = new();
    public LimitedCache(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Ємність має бути додатною.");
        _capacity = capacity;
    }
    public void Add(TKey key, TValue value)
    {
        if (_values.ContainsKey(key))
        {
            _values[key] = value;
            return;
        }
        if (_values.Count >= _capacity)
        {
            var oldestKey = _evictionOrder.Dequeue();
            _values.Remove(oldestKey);
        }
        _values[key] = value;
        _evictionOrder.Enqueue(key);
    }
    public bool TryGet(TKey key, out TValue value) => _values.TryGetValue(key, out value!);
}

