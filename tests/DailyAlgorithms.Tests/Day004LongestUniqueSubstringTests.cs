using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

public sealed class Day004LongestUniqueSubstringTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("a", 1)]
    [InlineData("aa", 1)]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("abba", 2)]
    [InlineData("dvdf", 3)]
    [InlineData("tmmzuxt", 5)]
    [InlineData("abcdef", 6)]
    [InlineData("ab", 2)]
    [InlineData("aba", 2)]
    [InlineData("aab", 2)]
    [InlineData("abca", 3)]
    [InlineData("abcddef", 4)]
    [InlineData("anviaj", 5)]
    [InlineData("abcdeafgh", 8)]
    [InlineData("abcd", 4)]
    [InlineData(" ", 1)]
    [InlineData("   ", 1)]
    [InlineData("a b a", 3)]
    [InlineData("aA", 2)]
    [InlineData("aAaA", 2)]
    [InlineData("你好世界", 4)]
    [InlineData("你好你好", 2)]
    [InlineData("一二三二四", 3)]
    [InlineData("1234512345", 5)]
    [InlineData("\0a\0b", 3)]
    [InlineData("\ud83d\ude00\ud83d\ude00", 2)]
    public void ExamplesAndBoundaries_ReturnExpectedLength(string text, int expected)
    {
        Assert.Equal(expected, Day004LongestUniqueSubstring.LengthOfLongestSubstring(text));
    }

    [Fact]
    public void NullInput_ThrowsArgumentNullExceptionWithCorrectParameter()
    {
        var exception = Assert.Throws<ArgumentNullException>(
            () => Day004LongestUniqueSubstring.LengthOfLongestSubstring(null!));
        Assert.Equal("text", exception.ParamName);
    }

    [Fact]
    public void HundredThousandRepeatedCharacters_ReturnOne()
    {
        Assert.Equal(1, Day004LongestUniqueSubstring.LengthOfLongestSubstring(new string('a', 100_000)));
    }

    [Fact]
    public void LongRepeatedAlphabet_ReturnAlphabetLength()
    {
        var text = new string(Enumerable.Range(0, 100_000)
            .Select(index => (char)('a' + index % 26)).ToArray());
        Assert.Equal(26, Day004LongestUniqueSubstring.LengthOfLongestSubstring(text));
    }

    [Fact]
    public void EveryUtf16CodeUnitOnce_ReturnsFullLength()
    {
        var text = new string(Enumerable.Range(0, 65_536).Select(value => (char)value).ToArray());
        Assert.Equal(65_536, Day004LongestUniqueSubstring.LengthOfLongestSubstring(text));
    }

    [Fact]
    public void FixedSeedRandomInputs_MatchIndependentBruteForce()
    {
        var random = new Random(4004);
        char[] alphabet = ['a', 'b', 'c', 'A', ' ', '\0', '你', '好', '\ud83d', '\ude00'];
        for (var caseIndex = 0; caseIndex < 400; caseIndex++)
        {
            var characters = new char[random.Next(0, 50)];
            for (var index = 0; index < characters.Length; index++)
            {
                characters[index] = alphabet[random.Next(alphabet.Length)];
            }
            var text = new string(characters);
            Assert.Equal(SolveByBruteForce(text), Day004LongestUniqueSubstring.LengthOfLongestSubstring(text));
        }
    }

    private static int SolveByBruteForce(string text)
    {
        var best = 0;
        for (var start = 0; start < text.Length; start++)
        {
            var seen = new HashSet<char>();
            for (var end = start; end < text.Length && seen.Add(text[end]); end++)
            {
                best = Math.Max(best, end - start + 1);
            }
        }
        return best;
    }
}
