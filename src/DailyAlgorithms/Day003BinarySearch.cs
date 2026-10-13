namespace DailyAlgorithms;

/// <summary>Day 003: Binary Search / 二分搜尋。</summary>
public static class Day003BinarySearch
{
    /// <summary>
    /// numbers 已依非遞減順序排列，回傳 target 第一次出現的索引。
    /// 找不到或陣列為空時回傳 -1；null 擲出 ArgumentNullException。
    /// 不得修改輸入。目標：O(log n) 時間、O(1) 額外空間。
    /// </summary>
    public static int FindFirstIndex(int[] numbers, int target)
    {
        ArgumentNullException.ThrowIfNull(numbers);
        // TODO: 找到目標值時，還需要確認是否存在更早的相同數值。
        throw new NotImplementedException("請完成 Day 003：找出第一次出現的索引。");
    }
}
