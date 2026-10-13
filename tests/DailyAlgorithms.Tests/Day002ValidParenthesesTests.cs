using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

public sealed class Day002ValidParenthesesTests
{
    [Theory]
    [InlineData("", true)]
    [InlineData("()", true)]
    [InlineData("[]", true)]
    [InlineData("{}", true)]
    [InlineData("()[]{}", true)]
    [InlineData("([])", true)]
    [InlineData("{[()]}", true)]
    [InlineData("[({})]", true)]
    [InlineData("(", false)]
    [InlineData(")", false)]
    [InlineData("(]", false)]
    [InlineData("([)]", false)]
    [InlineData("(()", false)]
    [InlineData("())", false)]
    [InlineData("{[}", false)]
    [InlineData(")(", false)]
    [InlineData("([]))", false)]
    [InlineData("((()))[]{}", true)]
    [InlineData("()a", false)]
    [InlineData(" ()", false)]
    [InlineData("（ ）", false)]
    public void TypicalAndEdgeCases_ReturnExpectedValidity(string brackets, bool expected)
    {
        Assert.Equal(expected, Day002ValidParentheses.IsValid(brackets));
    }

    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Day002ValidParentheses.IsValid(null!));
    }

    [Fact]
    public void VeryDeepNesting_IsValid()
    {
        var brackets = new string('(', 20_000) + new string(')', 20_000);
        Assert.True(Day002ValidParentheses.IsValid(brackets));
    }

    [Fact]
    public void LongStringWithWrongClosingOrder_IsInvalid()
    {
        var brackets = new string('(', 10_000) + new string(']', 10_000);
        Assert.False(Day002ValidParentheses.IsValid(brackets));
    }

    [Fact]
    public void LongAlternatingPairs_IsValid()
    {
        var brackets = string.Concat(Enumerable.Repeat("()[]{}", 5_000));
        Assert.True(Day002ValidParentheses.IsValid(brackets));
    }
}
