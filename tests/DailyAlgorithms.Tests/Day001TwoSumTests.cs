using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

public sealed class Day001TwoSumTests
{
    [Fact]
    public void TypicalCase_ReturnsCorrectIndices()
    {
        Assert.Equal(new[] { 0, 1 }, Day001TwoSum.Solve(new[] { 2, 7, 11, 15 }, 9));
    }

    [Fact]
    public void DuplicateValues_CanUseTwoDistinctElements()
    {
        Assert.Equal(new[] { 0, 1 }, Day001TwoSum.Solve(new[] { 3, 3 }, 6));
    }

    [Fact]
    public void NegativeNumbers_WorkCorrectly()
    {
        Assert.Equal(new[] { 0, 2 }, Day001TwoSum.Solve(new[] { -3, 4, 3, 90 }, 0));
    }

    [Fact]
    public void MultipleAnswers_AnyValidOrderedPairIsAccepted()
    {
        var numbers = new[] { 1, 2, 3, 4 };
        var indices = Day001TwoSum.Solve(numbers, 5);

        Assert.Equal(2, indices.Length);
        Assert.InRange(indices[0], 0, numbers.Length - 1);
        Assert.InRange(indices[1], 0, numbers.Length - 1);
        Assert.True(indices[0] < indices[1], "索引必須依照遞增順序，且不能重複使用相同元素");
        Assert.Equal((long)5, (long)numbers[indices[0]] + numbers[indices[1]]);
    }

    [Theory]
    [InlineData(new int[] { }, 1)]
    [InlineData(new int[] { 42 }, 84)]
    [InlineData(new int[] { 1, 2, 3 }, 10)]
    [InlineData(new int[] { 3, 4 }, 6)]
    public void NoValidPair_ReturnsEmptyArray(int[] numbers, int target)
    {
        Assert.Empty(Day001TwoSum.Solve(numbers, target));
    }

    [Fact]
    public void MaxValue_WithValidComplement_ReturnsCorrectIndices()
    {
        Assert.Equal(new[] { 0, 1 },
            Day001TwoSum.Solve(new[] { int.MaxValue, -1 }, int.MaxValue - 1));
    }

    [Fact]
    public void ArithmeticOverflow_DoesNotCreateFalsePositive()
    {
        Assert.Empty(Day001TwoSum.Solve(new[] { int.MaxValue, int.MaxValue }, -2));
    }

    [Fact]
    public void MinValueArithmeticOverflow_DoesNotCreateFalsePositive()
    {
        Assert.Empty(Day001TwoSum.Solve(new[] { int.MinValue, int.MinValue }, 0));
    }

    [Fact]
    public void InputArray_MustRemainUnchanged()
    {
        var numbers = new[] { 11, 5, -2, 7 };
        var copy = (int[])numbers.Clone();

        _ = Day001TwoSum.Solve(numbers, 9);

        Assert.Equal(copy, numbers);
    }

    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Day001TwoSum.Solve(null!, 10));
    }
}
