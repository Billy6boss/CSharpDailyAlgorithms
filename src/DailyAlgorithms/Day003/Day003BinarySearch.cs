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

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
            {
                return i;
            }
        }

        return -1;
    }
}
