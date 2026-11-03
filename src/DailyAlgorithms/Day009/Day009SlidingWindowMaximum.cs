namespace DailyAlgorithms;

/// <summary>
/// Day 009: Sliding Window Maximum（滑動視窗最大值）。
/// 保留 TODO，請先自行完成，再閱讀 mentor 裡的獨立參考解答。
/// </summary>
public static class Day009SlidingWindowMaximum
{
    /// <summary>
    /// 回傳每一個長度為 k 的連續視窗內的最大值。
    /// 輸入不可修改；目標均攤 O(n) 時間、額外 O(k) 空間（輸出除外）。
    /// </summary>
    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        ArgumentNullException.ThrowIfNull(nums);
        if (k <= 0 || k > nums.Length)
            throw new ArgumentOutOfRangeException(nameof(k));

        // TODO: 維護單調雙端佇列，儲存仍可能成為視窗最大值的「索引」。
        // TODO: 移除過期索引，並處理比新值小或相等的舊候選值。
        // TODO: 將每個完整視窗的最大值填入新陣列。
        throw new NotImplementedException();
    }
}
