using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

public sealed class Day005MaximumSubarrayTests
{
    [Theory]
    [InlineData(new int[] { }, 0L)]
    [InlineData(new int[] { 1 }, 1L)]
    [InlineData(new int[] { 0 }, 0L)]
    [InlineData(new int[] { -1 }, -1L)]
    [InlineData(new int[] { int.MaxValue }, 2147483647L)]
    [InlineData(new int[] { int.MinValue }, -2147483648L)]
    [InlineData(new int[] { 1, 2, 3 }, 6L)]
    [InlineData(new int[] { -1, -2, -3 }, -1L)]
    [InlineData(new int[] { 0, 0, 0 }, 0L)]
    [InlineData(new int[] { -2, -1, -3 }, -1L)]
    [InlineData(new int[] { 1, -1, 1 }, 1L)]
    [InlineData(new int[] { 5, -2, 3 }, 6L)]
    [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6L)]
    [InlineData(new int[] { 5, 4, -1, 7, 8 }, 23L)]
    [InlineData(new int[] { -5, 4, 3 }, 7L)]
    [InlineData(new int[] { 4, 3, -5 }, 7L)]
    [InlineData(new int[] { -5, 4, 3, -9, 2 }, 7L)]
    [InlineData(new int[] { 2, -5, 3, 4, -1, 2, -7, 6 }, 8L)]
    [InlineData(new int[] { 8, -19, 5, -4, 20 }, 21L)]
    [InlineData(new int[] { -2, 0, -1 }, 0L)]
    [InlineData(new int[] { 1, -2, 0, 3 }, 3L)]
    [InlineData(new int[] { 2, -1, 2, -1, 2 }, 4L)]
    [InlineData(new int[] { 10, -20, 10 }, 10L)]
    [InlineData(new int[] { -8, -3, -6, -2, -5, -4 }, -2L)]
    [InlineData(new int[] { int.MaxValue, int.MaxValue }, 4294967294L)]
    [InlineData(new int[] { int.MinValue, int.MaxValue }, 2147483647L)]
    [InlineData(new int[] { int.MaxValue, int.MinValue, int.MaxValue }, 2147483647L)]
    [InlineData(new int[] { int.MinValue, int.MinValue, 1 }, 1L)]
    [InlineData(new int[] { int.MaxValue, 1, -2 }, 2147483648L)]
    [InlineData(new int[] { int.MaxValue, int.MaxValue, int.MinValue }, 4294967294L)]
    [InlineData(new int[] { int.MinValue, int.MaxValue, int.MaxValue }, 4294967294L)]
    [InlineData(new int[] { int.MaxValue, int.MinValue, -1, int.MaxValue }, 2147483647L)]
    public void ExamplesAndBoundaries_ReturnExpectedSum(int[] numbers, long expected)
    {
        Assert.Equal(expected, Day005MaximumSubarray.Solve(numbers));
    }

    [Fact]
    public void NullInput_ThrowsArgumentNullExceptionWithCorrectParameter()
    {
        var exception = Assert.Throws<ArgumentNullException>(
            () => Day005MaximumSubarray.Solve(null!));
        Assert.Equal("numbers", exception.ParamName);
    }

    [Fact]
    public void InputArray_RemainsUnchanged()
    {
        int[] numbers = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
        var original = (int[])numbers.Clone();

        Assert.Equal(6L, Day005MaximumSubarray.Solve(numbers));
        Assert.Equal(original, numbers);
    }

    [Fact]
    public void FixedSeedRandomInputs_MatchIndependentBruteForce()
    {
        var random = new Random(5005);
        for (var caseIndex = 0; caseIndex < 1000; caseIndex++)
        {
            var numbers = new int[random.Next(0, 50)];
            for (var index = 0; index < numbers.Length; index++)
            {
                numbers[index] = random.Next(10) switch
                {
                    0 => int.MinValue,
                    1 => int.MaxValue,
                    _ => random.Next(-30, 31)
                };
            }

            var original = (int[])numbers.Clone();
            var expected = SolveByBruteForce(numbers);
            var actual = Day005MaximumSubarray.Solve(numbers);
            Assert.True(expected == actual,
                $"Case {caseIndex}: [{string.Join(", ", numbers)}], expected {expected}, actual {actual}");
            Assert.Equal(original, numbers);
        }
    }

    [Fact]
    public void HundredThousandMaxValues_AccumulatesInLong()
    {
        var numbers = Enumerable.Repeat(int.MaxValue, 100_000).ToArray();
        Assert.Equal(214748364700000L, Day005MaximumSubarray.Solve(numbers));
    }

    [Fact]
    public void HundredThousandNegativeValues_MustChooseAnElement()
    {
        var numbers = Enumerable.Repeat(-7, 100_000).ToArray();
        Assert.Equal(-7L, Day005MaximumSubarray.Solve(numbers));
    }

    [Fact]
    public void LargeNegativePrefix_CanRestartAtTheLastElement()
    {
        var numbers = Enumerable.Repeat(int.MinValue, 100_000).ToArray();
        numbers[^1] = 9;
        Assert.Equal(9L, Day005MaximumSubarray.Solve(numbers));
    }

    [Fact]
    public void RepeatedCalls_DoNotShareState()
    {
        Assert.Equal(6L, Day005MaximumSubarray.Solve([1, 2, 3]));
        Assert.Equal(-2L, Day005MaximumSubarray.Solve([-5, -2, -9]));
        Assert.Equal(0L, Day005MaximumSubarray.Solve([]));
        Assert.Equal(6L, Day005MaximumSubarray.Solve([1, 2, 3]));
    }

    // 此 oracle 枚舉所有連續區間，與線性參考演算法使用不同方法。
    private static long SolveByBruteForce(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return 0;
        }

        var best = long.MinValue;
        for (var start = 0; start < numbers.Length; start++)
        {
            long sum = 0;
            for (var end = start; end < numbers.Length; end++)
            {
                sum += numbers[end];
                best = Math.Max(best, sum);
            }
        }

        return best;
    }
}
