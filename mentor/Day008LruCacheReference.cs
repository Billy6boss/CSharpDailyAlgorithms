// Day 008 mentor reference only; this file is outside the compiled project.
using System;
using System.Collections.Generic;

namespace DailyAlgorithms.Mentor;

/// <summary>
/// O(1) average Get/Put via Dictionary + LinkedList, for self-review after finishing.
/// </summary>
public sealed class Day008LruCacheReference
{
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> _nodes = new();
    // First = most recently used; Last = least recently used.
    private readonly LinkedList<(int Key, int Value)> _usage = new();

    public Day008LruCacheReference(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (!_nodes.TryGetValue(key, out var node))
            return -1;

        Touch(node);
        return node.Value.Value;
    }

    public void Put(int key, int value)
    {
        if (_nodes.TryGetValue(key, out var node))
        {
            node.Value = (key, value);
            Touch(node);
            return;
        }

        if (_capacity == 0)
            return;

        if (_nodes.Count == _capacity)
        {
            var oldest = _usage.Last!;
            _nodes.Remove(oldest.Value.Key);
            _usage.RemoveLast();
        }

        var newest = _usage.AddFirst((key, value));
        _nodes.Add(key, newest);
    }

    private void Touch(LinkedListNode<(int Key, int Value)> node)
    {
        _usage.Remove(node);
        _usage.AddFirst(node);
    }
}
