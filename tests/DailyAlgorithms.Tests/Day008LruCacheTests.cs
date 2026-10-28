using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

/// <summary>
/// Day 008: 32 MemberData sequences + 14 Fact tests = 46 xUnit cases.
/// The slow test oracle uses a list and deliberately differs from the O(1) target design.
/// </summary>
public sealed class Day008LruCacheTests
{
    private static int[] P(int key, int value) => [0, key, value, 0];
    private static int[] G(int key, int expected) => [1, key, 0, expected];

    public static IEnumerable<object[]> OperationScenarios()
    {
        // 12 explicit examples: capacity, eviction, updates, misses, extremes.
        yield return new object[] { 0, new[] { P(1, 1), G(1, -1) } };
        yield return new object[] { 1, new[] { P(1, 10), G(1, 10) } };
        yield return new object[] { 1, new[] { P(1, 10), P(2, 20), G(1, -1), G(2, 20) } };
        yield return new object[] { 2, new[] { P(1, 1), P(2, 2), G(1, 1), P(3, 3), G(2, -1), G(1, 1), G(3, 3) } };
        yield return new object[] { 2, new[] { P(1, 1), P(2, 2), P(1, 10), P(3, 3), G(2, -1), G(1, 10) } };
        yield return new object[] { 2, new[] { P(1, 1), P(2, 2), G(3, -1), P(4, 4), G(1, -1), G(2, 2), G(4, 4) } };
        yield return new object[] { 2, new[] { P(1, 1), P(2, 2), G(1, 1), G(1, 1), P(3, 3), G(2, -1) } };
        yield return new object[] { 3, new[] { P(1, 1), P(2, 2), P(3, 3), P(4, 4), G(1, -1), G(2, 2), G(3, 3), G(4, 4) } };
        yield return new object[] { 2, new[] { P(0, 0), P(-1, -1), G(-1, -1), P(2, 2), G(0, -1), G(-1, -1) } };
        yield return new object[] { 1, new[] { G(1, -1), P(1, 7), G(2, -1), G(1, 7) } };
        yield return new object[] { 3, new[] { P(-9, 99), P(9, -99), P(0, 0), G(-9, 99), P(1, 1), G(9, -1), G(-9, 99) } };
        yield return new object[] { 2, new[] { P(int.MaxValue, int.MinValue), P(int.MinValue, int.MaxValue), G(int.MaxValue, int.MinValue), P(0, 0), G(int.MinValue, -1), G(int.MaxValue, int.MinValue) } };

        // 20 deterministic randomized scenarios using the independent linear oracle.
        for (var scenario = 0; scenario < 20; scenario++)
        {
            var random = new Random(8008 + scenario);
            var capacity = scenario % 6;
            var oracle = new SlowLru(capacity);
            var operations = new List<int[]>();

            for (var operation = 0; operation < 100; operation++)
            {
                var key = random.Next(12) == 0
                    ? int.MinValue
                    : random.Next(-9, 10);

                if (random.Next(100) < 47)
                {
                    operations.Add(G(key, oracle.Get(key)));
                }
                else
                {
                    var value = random.Next(10) == 0
                        ? int.MaxValue
                        : random.Next(-200, 201);
                    oracle.Put(key, value);
                    operations.Add(P(key, value));
                }
            }

            yield return new object[] { capacity, operations.ToArray() };
        }
    }

    [Theory]
    [MemberData(nameof(OperationScenarios))]
    public void OperationScenarios_RespectLruBehavior(int capacity, int[][] operations)
    {
        var cache = new Day008LruCache(capacity);
        foreach (var item in operations)
        {
            if (item[0] == 0)
                cache.Put(item[1], item[2]);
            else
                Assert.Equal(item[3], cache.Get(item[1]));
        }
    }

    [Fact]
    public void NegativeCapacity_ThrowsArgumentOutOfRangeException()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Day008LruCache(-1));
        Assert.Equal("capacity", ex.ParamName);
    }

    [Fact]
    public void CapacityZero_NeverStoresItems()
    {
        var cache = new Day008LruCache(0);
        cache.Put(1, 100);
        cache.Put(2, 200);
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(-1, cache.Get(2));
    }

    [Fact]
    public void CapacityOne_EvictsThePreviousKey()
    {
        var cache = new Day008LruCache(1);
        cache.Put(1, 11);
        cache.Put(2, 22);
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(22, cache.Get(2));
        cache.Put(2, 222);
        Assert.Equal(222, cache.Get(2));
    }

    [Fact]
    public void SuccessfulGet_RefreshesRecency()
    {
        var cache = new Day008LruCache(2);
        cache.Put(1, 10);
        cache.Put(2, 20);
        Assert.Equal(10, cache.Get(1));
        cache.Put(3, 30);
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(10, cache.Get(1));
        Assert.Equal(30, cache.Get(3));
    }

    [Fact]
    public void ExistingPut_RefreshesRecencyAndUpdatesValue()
    {
        var cache = new Day008LruCache(2);
        cache.Put(1, 10);
        cache.Put(2, 20);
        cache.Put(1, 100);
        cache.Put(3, 30);
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(100, cache.Get(1));
        Assert.Equal(30, cache.Get(3));
    }

    [Fact]
    public void MissingGet_DoesNotChangeRecency()
    {
        var cache = new Day008LruCache(2);
        cache.Put(1, 10);
        cache.Put(2, 20);
        Assert.Equal(-1, cache.Get(999));
        cache.Put(3, 30);
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(20, cache.Get(2));
    }

    [Fact]
    public void RepeatedUpdates_DoNotConsumeNewSlots()
    {
        var cache = new Day008LruCache(2);
        for (var i = 0; i < 1000; i++)
            cache.Put(1, i);
        cache.Put(2, 2000);
        Assert.Equal(999, cache.Get(1));
        Assert.Equal(2000, cache.Get(2));
        cache.Put(3, 3000);
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(2000, cache.Get(2));
    }

    [Fact]
    public void ExtremeKeysAndValues_AreSupported()
    {
        var cache = new Day008LruCache(2);
        cache.Put(int.MinValue, int.MaxValue);
        cache.Put(int.MaxValue, int.MinValue);
        Assert.Equal(int.MaxValue, cache.Get(int.MinValue));
        Assert.Equal(int.MinValue, cache.Get(int.MaxValue));
    }

    [Fact]
    public void StoredNegativeOne_IsStillATouch()
    {
        var cache = new Day008LruCache(2);
        cache.Put(1, -1);
        cache.Put(2, 20);
        Assert.Equal(-1, cache.Get(1)); // A hit, despite returning the sentinel value.
        cache.Put(3, 30);
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(30, cache.Get(3));
    }

    [Fact]
    public void DifferentCacheInstances_DoNotShareState()
    {
        var first = new Day008LruCache(1);
        var second = new Day008LruCache(2);
        first.Put(1, 11);
        second.Put(1, 111);
        second.Put(2, 222);
        Assert.Equal(11, first.Get(1));
        Assert.Equal(111, second.Get(1));
        Assert.Equal(222, second.Get(2));
    }

    [Fact]
    public void ManyDistinctKeys_CanCoexistAtLargeCapacity()
    {
        const int count = 10000;
        var cache = new Day008LruCache(count);
        for (var i = 0; i < count; i++)
            cache.Put(i - count / 2, i + 1);

        for (var i = 0; i < count; i += 127)
            Assert.Equal(i + 1, cache.Get(i - count / 2));
    }

    [Fact]
    public void ManyOperations_EvictExactlyOneOldestItem()
    {
        const int count = 20000;
        var cache = new Day008LruCache(count);
        for (var i = 0; i < count; i++)
            cache.Put(i, i * 2);

        Assert.Equal(0, cache.Get(0));
        cache.Put(count, 42);
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(0, cache.Get(0));
        Assert.Equal(42, cache.Get(count));
        Assert.Equal((count - 1) * 2, cache.Get(count - 1));
    }

    [Fact]
    public void RecencyDependsOnOperations_NotNumericKeyOrder()
    {
        var cache = new Day008LruCache(3);
        cache.Put(100, 1);
        cache.Put(-50, 2);
        cache.Put(0, 3);
        cache.Put(200, 4);
        Assert.Equal(-1, cache.Get(100));
        Assert.Equal(2, cache.Get(-50));
        Assert.Equal(3, cache.Get(0));
        Assert.Equal(4, cache.Get(200));
    }

    [Fact]
    public void RandomizedOperations_MatchSlowListOracle()
    {
        for (var trial = 0; trial < 150; trial++)
        {
            var random = new Random(18008 + trial);
            var capacity = trial % 9;
            var cache = new Day008LruCache(capacity);
            var oracle = new SlowLru(capacity);
            for (var operation = 0; operation < 200; operation++)
            {
                var key = random.Next(-20, 21);
                if (random.Next(100) < 50)
                {
                    var expected = oracle.Get(key);
                    var actual = cache.Get(key);
                    Assert.True(expected == actual,
                        $"Trial {trial}, operation {operation}, key {key}: expected {expected}, actual {actual}");
                }
                else
                {
                    var value = random.Next(-500, 501);
                    oracle.Put(key, value);
                    cache.Put(key, value);
                }
            }
        }
    }

    // Slow, independent correctness oracle. Deliberately O(capacity) per operation.
    private sealed class SlowLru
    {
        private readonly int _capacity;
        private readonly List<(int Key, int Value)> _items = [];

        public SlowLru(int capacity) => _capacity = capacity;

        public int Get(int key)
        {
            var index = _items.FindIndex(x => x.Key == key);
            if (index < 0)
                return -1;
            var pair = _items[index];
            _items.RemoveAt(index);
            _items.Add(pair);
            return pair.Value;
        }

        public void Put(int key, int value)
        {
            var index = _items.FindIndex(x => x.Key == key);
            if (index >= 0)
                _items.RemoveAt(index);

            if (_capacity == 0)
                return;

            if (_items.Count == _capacity)
                _items.RemoveAt(0);
            _items.Add((key, value));
        }
    }
}
