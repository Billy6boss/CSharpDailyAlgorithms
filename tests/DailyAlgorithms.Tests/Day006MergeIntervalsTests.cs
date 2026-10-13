using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

public sealed class Day006MergeIntervalsTests
{
    private static int[][] Intervals(params (int Start, int End)[] values) =>
        values.Select(value => new[] { value.Start, value.End }).ToArray();

    public static IEnumerable<object[]> Examples()
    {
        yield return new object[] { Intervals(), Intervals() };
        yield return new object[] { Intervals((1, 2)), Intervals((1, 2)) };
        yield return new object[] { Intervals((1, 2), (4, 5)), Intervals((1, 2), (4, 5)) };
        yield return new object[] { Intervals((4, 5), (1, 2)), Intervals((1, 2), (4, 5)) };
        yield return new object[] { Intervals((1, 4), (4, 5)), Intervals((1, 5)) };
        yield return new object[] { Intervals((1, 2), (3, 4)), Intervals((1, 2), (3, 4)) };
        yield return new object[] { Intervals((1, 10), (2, 3)), Intervals((1, 10)) };
        yield return new object[] { Intervals((1, 2), (1, 2)), Intervals((1, 2)) };
        yield return new object[] { Intervals((1, 4), (1, 2)), Intervals((1, 4)) };
        yield return new object[] { Intervals((1, 4), (2, 4)), Intervals((1, 4)) };
        yield return new object[] { Intervals((-5, -1), (-3, 2)), Intervals((-5, 2)) };
        yield return new object[] { Intervals((-5, -3), (-2, -1)), Intervals((-5, -3), (-2, -1)) };
        yield return new object[] { Intervals((0, 0)), Intervals((0, 0)) };
        yield return new object[] { Intervals((1, 10), (5, 5)), Intervals((1, 10)) };
        yield return new object[] { Intervals((1, 4), (4, 4)), Intervals((1, 4)) };
        yield return new object[] { Intervals((1, 1), (2, 2)), Intervals((1, 1), (2, 2)) };
        yield return new object[] { Intervals((1, 3), (2, 4), (4, 6)), Intervals((1, 6)) };
        yield return new object[] { Intervals((1, 10), (2, 9), (3, 8)), Intervals((1, 10)) };
        yield return new object[] { Intervals((5, 7), (1, 3), (3, 5)), Intervals((1, 7)) };
        yield return new object[] { Intervals((1, 2), (2, 3), (10, 11)), Intervals((1, 3), (10, 11)) };
        yield return new object[] { Intervals((3, 3), (3, 3)), Intervals((3, 3)) };
        yield return new object[] { Intervals((-3, 0), (0, 0)), Intervals((-3, 0)) };
        yield return new object[] { Intervals((9, 11), (5, 7), (1, 3)), Intervals((1, 3), (5, 7), (9, 11)) };
        yield return new object[] { Intervals((int.MinValue, -1), (-1, int.MaxValue)), Intervals((int.MinValue, int.MaxValue)) };
        yield return new object[] { Intervals((int.MaxValue - 1, int.MaxValue), (int.MinValue, int.MinValue + 1)), Intervals((int.MinValue, int.MinValue + 1), (int.MaxValue - 1, int.MaxValue)) };
        yield return new object[] { Intervals((2, 5), (2, 8), (2, 3)), Intervals((2, 8)) };
        yield return new object[] { Intervals((-2, -1), (0, 1)), Intervals((-2, -1), (0, 1)) };
        yield return new object[] { Intervals((10, 12), (3, 4), (4, 10)), Intervals((3, 12)) };
        yield return new object[] { Intervals((1, 4), (0, 2), (7, 9), (8, 10)), Intervals((0, 4), (7, 10)) };
        yield return new object[] { Intervals((1, 6), (2, 4), (7, 9), (5, 8)), Intervals((1, 9)) };
        yield return new object[] { Intervals((-10, -5), (-6, -1), (0, 0), (1, 2)), Intervals((-10, -1), (0, 0), (1, 2)) };
        yield return new object[] { Intervals((1, 2), (2, 2), (2, 3), (3, 3)), Intervals((1, 3)) };
    }

    [Theory]
    [MemberData(nameof(Examples))]
    public void Examples_ReturnExpectedIntervals(int[][] input, int[][] expected)
    {
        AssertIntervalsEqual(expected, Day006MergeIntervals.Merge(input));
    }

    [Fact]
    public void NullOuterArray_ThrowsArgumentNullException()
    {
        var error = Assert.Throws<ArgumentNullException>(
            () => Day006MergeIntervals.Merge(null!));
        Assert.Equal("intervals", error.ParamName);
    }

    [Fact]
    public void NullInnerArray_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => Day006MergeIntervals.Merge(new int[][] { null! }));
    }

    [Fact]
    public void InvalidInterval_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Day006MergeIntervals.Merge(new[] { new[] { 1 } }));
        Assert.Throws<ArgumentException>(() => Day006MergeIntervals.Merge(new[] { new[] { 1, 2, 3 } }));
        Assert.Throws<ArgumentException>(() => Day006MergeIntervals.Merge(Intervals((5, 4))));
    }

    [Fact]
    public void InputAndInnerArrays_AreNotModified()
    {
        var input = Intervals((9, 10), (1, 4), (2, 6), (-1, 0));
        var rows = input.ToArray();
        var values = input.Select(row => row.ToArray()).ToArray();

        AssertIntervalsEqual(Intervals((-1, 0), (1, 6), (9, 10)),
            Day006MergeIntervals.Merge(input));

        for (var i = 0; i < input.Length; i++)
        {
            Assert.Same(rows[i], input[i]);
            Assert.Equal(values[i], input[i]);
        }
    }

    [Fact]
    public void ResultRows_DoNotReferenceInputRows()
    {
        var input = Intervals((1, 2));
        var output = Day006MergeIntervals.Merge(input);
        AssertIntervalsEqual(Intervals((1, 2)), output);
        Assert.NotSame(input, output);
        Assert.NotSame(input[0], output[0]);
    }

    [Fact]
    public void FiftyThousandDisjointIntervals_AreSorted()
    {
        const int count = 50_000;
        var input = Enumerable.Range(0, count)
            .Select(i => new[] { (count - i) * 3, (count - i) * 3 + 1 })
            .ToArray();

        var result = Day006MergeIntervals.Merge(input);
        Assert.Equal(count, result.Length);
        for (var i = 0; i < count; i++)
        {
            Assert.Equal((i + 1) * 3, result[i][0]);
            Assert.Equal((i + 1) * 3 + 1, result[i][1]);
        }
    }

    [Fact]
    public void RandomInputs_MatchIndependentGraphOracle()
    {
        var random = new Random(20261013);
        for (var caseIndex = 0; caseIndex < 350; caseIndex++)
        {
            var count = random.Next(0, 19);
            var input = new int[count][];
            for (var i = 0; i < count; i++)
            {
                var a = random.Next(-30, 31);
                var b = random.Next(-30, 31);
                input[i] = new[] { Math.Min(a, b), Math.Max(a, b) };
            }

            AssertIntervalsEqual(IndependentGraphOracle(input),
                Day006MergeIntervals.Merge(input));
        }
    }

    // 不用排序後貪婪法，改用重疊圖的連通分量做交叉驗證。
    private static int[][] IndependentGraphOracle(int[][] input)
    {
        var seen = new bool[input.Length];
        var result = new List<int[]>();
        for (var i = 0; i < input.Length; i++)
        {
            if (seen[i]) continue;

            var stack = new Stack<int>();
            stack.Push(i);
            seen[i] = true;
            var minStart = int.MaxValue;
            var maxEnd = int.MinValue;

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                minStart = Math.Min(minStart, input[current][0]);
                maxEnd = Math.Max(maxEnd, input[current][1]);
                for (var j = 0; j < input.Length; j++)
                {
                    if (!seen[j]
                        && input[current][0] <= input[j][1]
                        && input[j][0] <= input[current][1])
                    {
                        seen[j] = true;
                        stack.Push(j);
                    }
                }
            }

            result.Add(new[] { minStart, maxEnd });
        }
        return result.OrderBy(row => row[0]).ThenBy(row => row[1]).ToArray();
    }

    private static void AssertIntervalsEqual(int[][] expected, int[][] actual)
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Length, actual.Length);
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.NotNull(actual[i]);
            Assert.Equal(2, actual[i].Length);
            Assert.Equal(expected[i][0], actual[i][0]);
            Assert.Equal(expected[i][1], actual[i][1]);
        }
    }
}
