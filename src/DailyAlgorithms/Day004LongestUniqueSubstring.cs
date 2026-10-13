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
    public static int LengthOfLongestSubstring(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        // TODO: 使用滑動視窗；處理 abba 時左界不能向後退。
        throw new NotImplementedException("請完成 Day 004：最長不重複字元子字串。");
    }
}
