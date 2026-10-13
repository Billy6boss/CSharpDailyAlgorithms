// 參考答案：不編入任何 .csproj；請先完成題目。
using System;
using System.Collections.Generic;

namespace DailyAlgorithms.Mentor;

public static class Day004LongestUniqueSubstringReference
{
    public static int LengthOfLongestSubstring(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        var lastIndexByCharacter = new Dictionary<char, int>();
        var left = 0;
        var best = 0;

        for (var right = 0; right < text.Length; right++)
        {
            var character = text[right];
            if (lastIndexByCharacter.TryGetValue(character, out var previousIndex) && previousIndex >= left)
            {
                left = previousIndex + 1;
            }
            lastIndexByCharacter[character] = right;
            best = Math.Max(best, right - left + 1);
        }

        return best;
    }
}
