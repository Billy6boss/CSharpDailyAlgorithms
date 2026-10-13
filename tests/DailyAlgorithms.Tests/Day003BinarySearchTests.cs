using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

public sealed class Day003BinarySearchTests
{
    [Theory]
    [InlineData(new int[] { }, 0, -1)]
    [InlineData(new int[] { 1 }, 1, 0)]
    [InlineData(new int[] { 1 }, 0, -1)]
    [InlineData(new int[] { 1 }, 2, -1)]
    [InlineData(new int[] { 1, 3, 5, 7 }, 4, -1)]
    [InlineData(new int[] { 1, 3, 5, 7 }, 1, 0)]
    [InlineData(new int[] { 1, 3, 5, 7 }, 7, 3)]
    [InlineData(new int[] { 1, 3, 5, 7 }, 5, 2)]
    [InlineData(new int[] { -3, -1, 2, 2, 2, 9 }, 2, 2)]
    [InlineData(new int[] { 1, 1, 1 }, 1, 0)]
    [InlineData(new int[] { -10, -5, -5, 0, 5 }, -5, 1)]
    [InlineData(new int[] { 0, 0, 0, 1, 2 }, 0, 0)]
    [InlineData(new int[] { 1, 2, 3, 3, 3 }, 3, 2)]
    [InlineData(new int[] { int.MinValue, 0, int.MaxValue }, int.MinValue, 0)]
    [InlineData(new int[] { int.MinValue, 0, int.MaxValue }, int.MaxValue, 2)]
    [InlineData(new int[] { int.MinValue, int.MinValue, 0 }, int.MinValue, 0)]
    [InlineData(new int[] { 0, int.MaxValue, int.MaxValue }, int.MaxValue, 1)]
    [InlineData(new int[] { -5, -4, -3 }, -2, -1)]
    [InlineData(new int[] { -5, -4, -3 }, -6, -1)]
    [InlineData(new int[] { 2, 4, 6, 8 }, 5, -1)]
    [InlineData(new int[] { -3, -1, 0, 2 }, 0, 2)]
    [InlineData(new int[] { 0 }, 0, 0)]
    [InlineData(new int[] { -1 }, -1, 0)]
    [InlineData(new int[] { -2, -2, -2, 0, 0, 3 }, 0, 3)]
    public void SortedExamples_ReturnFirstIndex(int[] numbers, int target, int expected)
    {
        Assert.Equal(expected, Day003BinarySearch.FindFirstIndex(numbers, target));
    }

    [Fact]
    public void NullInput_ThrowsArgumentNullExceptionWithCorrectParameter()
    {
        var exception = Assert.Throws<ArgumentNullException>(
            () => Day003BinarySearch.FindFirstIndex(null!, 0));
        Assert.Equal("numbers", exception.ParamName);
    }

    [Fact]
    public void InputArray_RemainsUnchanged()
    {
        int[] numbers = [-3, -1, 2, 2, 2, 9];
        var original = (int[])numbers.Clone();
        Assert.Equal(2, Day003BinarySearch.FindFirstIndex(numbers, 2));
        Assert.Equal(original, numbers);
    }

    [Fact]
    public void LargeDuplicateGroups_ReturnFirstIndex()
    {
        var numbers = Enumerable.Range(0, 100_000).Select(index => index / 10).ToArray();
        Assert.Equal(77_770, Day003BinarySearch.FindFirstIndex(numbers, 7_777));
        Assert.Equal(0, Day003BinarySearch.FindFirstIndex(numbers, 0));
        Assert.Equal(99_990, Day003BinarySearch.FindFirstIndex(numbers, 9_999));
        Assert.Equal(-1, Day003BinarySearch.FindFirstIndex(numbers, 10_000));
        Assert.Equal(0, Day003BinarySearch.FindFirstIndex(new int[100_000], 0));
    }

    [Fact]
    public void LargeUniqueArray_HandlesBothEndsAndMissingTarget()
    {
        var numbers = Enumerable.Range(-50_000, 100_000).ToArray();
        Assert.Equal(0, Day003BinarySearch.FindFirstIndex(numbers, -50_000));
        Assert.Equal(99_999, Day003BinarySearch.FindFirstIndex(numbers, 49_999));
        Assert.Equal(-1, Day003BinarySearch.FindFirstIndex(numbers, 50_000));
    }

    [Fact]
    public void FixedSeedRandomInputs_MatchIndependentLinearSearch()
    {
        var random = new Random(3003);
        for (var caseIndex = 0; caseIndex < 250; caseIndex++)
        {
            var numbers = new int[random.Next(0, 301)];
            for (var index = 0; index < numbers.Length; index++)
            {
                numbers[index] = random.Next(10) switch
                {
                    0 => int.MinValue,
                    1 => int.MaxValue,
                    _ => random.Next(-50, 51)
                };
            }
            Array.Sort(numbers);
            var original = (int[])numbers.Clone();
            var target = caseIndex % 3 == 0 && numbers.Length > 0
                ? numbers[random.Next(numbers.Length)]
                : random.Next(-60, 61);
            var expected = Array.IndexOf(numbers, target);
            Assert.Equal(expected, Day003BinarySearch.FindFirstIndex(numbers, target));
            Assert.Equal(original, numbers);
        }
    }
}
