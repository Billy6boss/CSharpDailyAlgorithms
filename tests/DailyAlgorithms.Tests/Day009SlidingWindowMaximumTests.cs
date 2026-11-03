using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

public sealed class Day009SlidingWindowMaximumTests
{
    public static IEnumerable<object[]> Examples()
    {
        // 26 independent, expected-value examples checked against a simple oracle.
        yield return new object[] { new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3, new[] { 3, 3, 5, 5, 6, 7 } };
        yield return new object[] { new[] { 1 }, 1, new[] { 1 } };
        yield return new object[] { new[] { 1, -1 }, 1, new[] { 1, -1 } };
        yield return new object[] { new[] { 9, 11 }, 2, new[] { 11 } };
        yield return new object[] { new[] { 4, -2 }, 2, new[] { 4 } };
        yield return new object[] { new[] { 1, 3, 1, 2, 0, 5 }, 3, new[] { 3, 3, 2, 5 } };
        yield return new object[] { new[] { -7, -8, 7, 5, 7, 1, 6, 0 }, 4, new[] { 7, 7, 7, 7, 7 } };
        yield return new object[] { new[] { 1, 1, 1, 1 }, 2, new[] { 1, 1, 1 } };
        yield return new object[] { new[] { 3, 3, 3, 3 }, 4, new[] { 3 } };
        yield return new object[] { new[] { 1, 2, 3, 4, 5 }, 2, new[] { 2, 3, 4, 5 } };
        yield return new object[] { new[] { 5, 4, 3, 2, 1 }, 2, new[] { 5, 4, 3, 2 } };
        yield return new object[] { new[] { -5, -4, -3, -2, -1 }, 3, new[] { -3, -2, -1 } };
        yield return new object[] { new[] { 0, 0, 0, 0 }, 1, new[] { 0, 0, 0, 0 } };
        yield return new object[] { new[] { 3, 1, 3, 1, 3, 1 }, 3, new[] { 3, 3, 3, 3 } };
        yield return new object[] { new[] { 8, 2, 4, 7 }, 2, new[] { 8, 4, 7 } };
        yield return new object[] { new[] { 2, 1, 5, 1, 3, 2 }, 3, new[] { 5, 5, 5, 3 } };
        yield return new object[] { new[] { 6, 5, 4, 3, 2, 1 }, 5, new[] { 6, 5 } };
        yield return new object[] { new[] { 5, 1, 5, 1, 5 }, 2, new[] { 5, 5, 5, 5 } };
        yield return new object[] { new[] { 2, 2, 1, 2, 2 }, 3, new[] { 2, 2, 2 } };
        yield return new object[] { new[] { -1, -3, -2, -4 }, 2, new[] { -1, -2, -2 } };
        yield return new object[] { new[] { int.MinValue, int.MaxValue, int.MinValue }, 2, new[] { int.MaxValue, int.MaxValue } };
        yield return new object[] { new[] { int.MaxValue, int.MinValue, int.MaxValue }, 3, new[] { int.MaxValue } };
        yield return new object[] { new[] { 1, 2, 1, 2, 1, 2 }, 5, new[] { 2, 2 } };
        yield return new object[] { new[] { 7, 7, 3, 7, 7 }, 3, new[] { 7, 7, 7 } };
        yield return new object[] { new[] { 10, -1, -1, 10, 0 }, 4, new[] { 10, 10 } };
        yield return new object[] { new[] { 0, -1, 1, -1, 0 }, 2, new[] { 0, 1, 1, 0 } };

        // 24 fixed-seed random cases, expected values from independent O(n*k) oracle.
        for (var trial = 0; trial < 24; trial++)
        {
            var random = new Random(20261103 + trial);
            var size = random.Next(1, 60);
            var nums = new int[size];
            for (var i = 0; i < size; i++)
            {
                var category = random.Next(20);
                nums[i] = category == 0 ? int.MinValue
                    : category == 1 ? int.MaxValue
                    : random.Next(-40, 41);
            }

            var k = random.Next(1, size + 1);
            yield return new object[] { nums, k, BruteForce(nums, k) };
        }
    }

    [Theory]
    [MemberData(nameof(Examples))]
    public void Examples_ReturnExpectedWindowMaxima(int[] nums, int k, int[] expected)
    {
        var original = (int[])nums.Clone();
        var actual = Day009SlidingWindowMaximum.MaxSlidingWindow(nums, k);
        Assert.Equal(expected, actual);
        Assert.Equal(original, nums);
    }

    [Fact]
    public void NullNums_ThrowsArgumentNullExceptionWithParamName()
    {
        var ex = Assert.Throws<ArgumentNullException>(
            () => Day009SlidingWindowMaximum.MaxSlidingWindow(null!, 1));
        Assert.Equal("nums", ex.ParamName);
    }

    [Fact]
    public void ZeroK_ThrowsArgumentOutOfRangeException()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { 1, 2 }, 0));
        Assert.Equal("k", ex.ParamName);
    }

    [Fact]
    public void NegativeK_ThrowsArgumentOutOfRangeException()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { 1, 2 }, -1));
        Assert.Equal("k", ex.ParamName);
    }

    [Fact]
    public void KLongerThanArray_ThrowsArgumentOutOfRangeException()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { 1, 2 }, 3));
        Assert.Equal("k", ex.ParamName);
    }

    [Fact]
    public void EmptyArray_HasNoValidWindowSize()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => Day009SlidingWindowMaximum.MaxSlidingWindow(Array.Empty<int>(), 1));
        Assert.Equal("k", ex.ParamName);
    }

    [Fact]
    public void OneElementWindow_ReturnsThatElement()
    {
        Assert.Equal(new[] { 42 }, Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { 42 }, 1));
    }

    [Fact]
    public void KOne_ReturnsAnIndependentArray()
    {
        int[] nums = [-3, 0, 2, int.MinValue, int.MaxValue];
        var actual = Day009SlidingWindowMaximum.MaxSlidingWindow(nums, 1);
        Assert.Equal(nums, actual);
        Assert.NotSame(nums, actual);
        actual[0] = 12345;
        Assert.Equal(-3, nums[0]);
    }

    [Fact]
    public void KEqualsArrayLength_ReturnsSingleMaximum()
    {
        Assert.Equal(new[] { 4 },
            Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { -8, 3, 1, 4, 4 }, 5));
    }

    [Fact]
    public void InputIsNotModifiedAndCallsAreRepeatable()
    {
        int[] nums = [2, 5, 1, 7, 7, -2, 4, 3];
        var before = (int[])nums.Clone();
        var first = Day009SlidingWindowMaximum.MaxSlidingWindow(nums, 3);
        var second = Day009SlidingWindowMaximum.MaxSlidingWindow(nums, 3);
        Assert.Equal(new[] { 5, 7, 7, 7, 7, 4 }, first);
        Assert.Equal(first, second);
        Assert.Equal(before, nums);
    }

    [Fact]
    public void DuplicatesDoNotCorruptMaximum()
    {
        Assert.Equal(new[] { 3, 3, 3, 3 },
            Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { 3, 3, 3, 3, 1, 3 }, 3));
    }

    [Fact]
    public void AllNegativeValuesAreHandled()
    {
        Assert.Equal(new[] { -4, -4, -3 },
            Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { -8, -4, -9, -3 }, 2));
    }

    [Fact]
    public void IntMinAndIntMaxDoNotOverflow()
    {
        Assert.Equal(new[] { int.MaxValue, int.MaxValue, int.MaxValue },
            Day009SlidingWindowMaximum.MaxSlidingWindow(
                new[] { int.MinValue, int.MaxValue, int.MinValue, int.MaxValue }, 2));
    }

    [Fact]
    public void VeryLargeIncreasingArray_HasExpectedMaxima()
    {
        const int n = 72000;
        const int k = 32000;
        var nums = Enumerable.Range(0, n).ToArray();
        var result = Day009SlidingWindowMaximum.MaxSlidingWindow(nums, k);
        Assert.Equal(n - k + 1, result.Length);
        for (var i = 0; i < result.Length; i++)
            Assert.Equal(i + k - 1, result[i]);
    }

    [Fact]
    public void VeryLargeDecreasingArray_HasExpectedMaxima()
    {
        const int n = 72000;
        const int k = 32000;
        var nums = Enumerable.Range(0, n).Select(i => n - i).ToArray();
        var result = Day009SlidingWindowMaximum.MaxSlidingWindow(nums, k);
        Assert.Equal(n - k + 1, result.Length);
        for (var i = 0; i < result.Length; i++)
            Assert.Equal(n - i, result[i]);
    }

    [Fact]
    public void VeryLargeConstantArray_HasExpectedMaxima()
    {
        const int n = 80000;
        const int k = 25000;
        var nums = Enumerable.Repeat(7, n).ToArray();
        var result = Day009SlidingWindowMaximum.MaxSlidingWindow(nums, k);
        Assert.Equal(n - k + 1, result.Length);
        foreach (var value in result)
            Assert.Equal(7, value);
    }

    [Fact]
    public void AlternatingIntExtremes_HaveCorrectMaxima()
    {
        const int n = 25000;
        var nums = Enumerable.Range(0, n)
            .Select(i => i % 2 == 0 ? int.MinValue : int.MaxValue).ToArray();
        var result = Day009SlidingWindowMaximum.MaxSlidingWindow(nums, 999);
        Assert.Equal(n - 999 + 1, result.Length);
        foreach (var value in result)
            Assert.Equal(int.MaxValue, value);
    }

    [Fact]
    public void RepeatedRandomArrays_MatchIndependentBruteForceOracle()
    {
        for (var trial = 0; trial < 300; trial++)
        {
            var random = new Random(90129 + trial);
            var n = random.Next(1, 90);
            var nums = new int[n];
            for (var i = 0; i < n; i++)
                nums[i] = random.Next(-100, 101);
            var k = random.Next(1, n + 1);
            Assert.Equal(BruteForce(nums, k),
                Day009SlidingWindowMaximum.MaxSlidingWindow(nums, k));
        }
    }

    [Fact]
    public void DifferentCallSizesDoNotShareMutableState()
    {
        Assert.Equal(new[] { 4, 5 }, Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { 1, 4, 2, 5 }, 3));
        Assert.Equal(new[] { -1, -1 }, Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { -1, -1 }, 1));
        Assert.Equal(new[] { 4, 5 }, Day009SlidingWindowMaximum.MaxSlidingWindow(new[] { 1, 4, 2, 5 }, 3));
    }

    [Fact]
    public void WindowsWithOnlyIntMinValueReturnIntMinValue()
    {
        Assert.Equal(new[] { int.MinValue, int.MinValue },
            Day009SlidingWindowMaximum.MaxSlidingWindow(
                new[] { int.MinValue, int.MinValue, int.MinValue }, 2));
    }

    [Fact]
    public void PeakLeavingWindowIsHandledCorrectly()
    {
        Assert.Equal(new[] { 1, 100, 100, 100, 1, 1 },
            Day009SlidingWindowMaximum.MaxSlidingWindow(
                new[] { 1, 1, 1, 100, 1, 1, 1, 1 }, 3));
    }

    private static int[] BruteForce(int[] nums, int k)
    {
        var expected = new int[nums.Length - k + 1];
        for (var start = 0; start < expected.Length; start++)
        {
            var max = nums[start];
            for (var offset = 1; offset < k; offset++)
                max = Math.Max(max, nums[start + offset]);
            expected[start] = max;
        }
        return expected;
    }
}
