namespace DailyAlgorithms;

/// <summary>
/// Day 006: Merge Intervals / 合併區間。
/// </summary>
public static class Day006MergeIntervals
{
    /// <summary>
    /// 將重疊的閉區間 [start, end] 合併，依起點遞增回傳。
    /// 相同端點算重疊，例如 [1,4] + [4,5] = [1,5]。
    /// null 外層陣列擲出 ArgumentNullException；
    /// 內層為 null、長度不是 2 或 start > end 擲出 ArgumentException。
    /// 不得修改輸入（包括內層陣列）；輸出不可共用輸入的內層陣列。
    /// 挑戰：O(n log n) 時間、O(n) 額外空間。
    /// </summary>
    public static int[][] Merge(int[][] intervals)
    {
        ArgumentNullException.ThrowIfNull(intervals);

        // TODO: 驗證每個區間，排序並合併重疊區間。
        throw new NotImplementedException("請完成 Day 006：Merge Intervals。");
    }
}
