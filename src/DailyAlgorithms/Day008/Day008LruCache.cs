namespace DailyAlgorithms;

/// <summary>
/// Day 008：LRU Cache（最近最少使用快取）。
/// 請自己實作，完成後再查看 mentor/ 中的參考答案。
/// </summary>
public sealed class Day008LruCache
{
    /// <summary>
    /// 建立容量固定的快取。容量可以為 0；負數應擲出
    /// ArgumentOutOfRangeException（參數名稱 capacity）。
    /// </summary>
    public Day008LruCache(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);

        // TODO: 選擇資料結構並初始化快取狀態。
        // 提示：Get / Put 都應達到平均 O(1) 時間。
    }

    /// <summary>
    /// 存在時回傳 value，並標記為最近使用；不存在時回傳 -1，
    /// 且不得變更任何已有項目的新舊順序。
    /// 即使 value 為 -1，也仍是有效的快取項目。
    /// </summary>
    public int Get(int key)
    {
        // TODO: 查詢與更新使用順序。
        throw new NotImplementedException("請實作 Day 008 的 Get。");
    }

    /// <summary>
    /// 新增或更新 key/value，並標記為最近使用。
    /// 容量已滿時，新增 key 必須淘汰「最久沒有被使用」的項目。
    /// 容量為 0 時不能儲存任何項目。
    /// </summary>
    public void Put(int key, int value)
    {
        // TODO: 更新、加入、淘汰與更新使用順序。
        throw new NotImplementedException("請實作 Day 008 的 Put。");
    }
}
