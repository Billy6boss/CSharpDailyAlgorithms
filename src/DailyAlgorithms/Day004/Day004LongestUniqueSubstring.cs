namespace DailyAlgorithms;

/// <summary>Day 004: Longest Substring Without Repeating Characters。</summary>
public static class Day004LongestUniqueSubstring
{
    /// <summary>
    /// 回傳不含重複 char 的最長連續子字串長度。
    /// 字元以 C# char（UTF-16 code unit）為單位，區分大小寫，不做正規化。
    /// 空字串回傳 0；null 擲出 ArgumentNullException。
    /// 目標：平均 O(n) 時間，O(min(n, 字元種類數)) 額外空間。
    /// </summary>
    /// <remarks>
    /// "abcabcbb" -> 3
    //"pwwkew"   -> 3
    //"pwpkew"   -> 4
    //"pwawkew"   -> 4
    //"abba"     -> 2
    //"aA"       -> 2
    //""         -> 0
    /// </remarks>
    public static int LengthOfLongestSubstring(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (text.Length == 0)
        {
            return 0;
        }
        
        var noneRepeatChar = new List<char>();
        var maxLength = 0;
        var ansStartIndex = 0;

        for (var index = 0; index < text.Length; index++)
        {
            var ogChar = text[index];
            var repeatCharIndex = noneRepeatChar.LastIndexOf(ogChar);
            if (repeatCharIndex != -1)
            {
                ansStartIndex = ansStartIndex > repeatCharIndex + 1 ? ansStartIndex : repeatCharIndex + 1;
            }
            
            var ansEndIndex = index;
            noneRepeatChar.Add(ogChar);

            maxLength = maxLength < ansEndIndex - ansStartIndex + 1 ? ansEndIndex - ansStartIndex + 1 : maxLength;
        }


        return maxLength;
        
        // correct but slow way
        // ArgumentNullException.ThrowIfNull(text);
        // var noneRepeatChar = new List<char>();
        // var maxLength = 0;
        //
        // foreach (var ogChar in text)
        // {
        //     var repeatCharIndex = noneRepeatChar.IndexOf(ogChar);
        //     if (noneRepeatChar.Contains(ogChar))
        //     {
        //         noneRepeatChar.RemoveRange(0, repeatCharIndex+1);
        //     }
        //     
        //     noneRepeatChar.Add(ogChar);
        //     
        //     maxLength = maxLength < noneRepeatChar.Count ? noneRepeatChar.Count : maxLength;
        // }
        //
        //
        // return maxLength;
    }
}
