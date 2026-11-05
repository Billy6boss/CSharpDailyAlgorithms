# Day 008｜LRU Cache（最近最少使用快取）

**原定出題日期**：2026-10-15　**補發日期**：2026-10-28　**難度**：Medium　**建議時間**：35～50 分鐘

## 題目說明

實作一個固定容量的 **LRU（Least Recently Used，最近最少使用）快取**。在快取容量已滿、又要加入新 key 時，必須淘汰「最久沒有成功讀取，也沒有被新增或更新」的項目。

請完成 `Day008LruCache` 類別的建構子、`Get` 和 `Put`：

```csharp
public sealed class Day008LruCache
{
    public Day008LruCache(int capacity);
    public int Get(int key);
    public void Put(int key, int value);
}
```

## 輸入與輸出契約

- `new Day008LruCache(capacity)`：設定可存放的最大**相異 key 數量**，容量固定不變。
- `Get(key)`：key 存在則回傳對應 `value`，並把它標記為**最近使用**；不存在則回傳 `-1`，不改變其他項目的使用順序。
- `Put(key, value)`：若 key 已存在則**更新 value** 並標記為最近使用；若不存在則新增，必要時淘汰最久未使用的 key。
- 容量為 **0** 合法：所有 `Put` 都不保存資料，所有 `Get` 都回傳 `-1`。
- 容量為**負數**應擲出 `ArgumentOutOfRangeException`，參數名稱必須是 `capacity`。
- key 和 value 都可以是任意 `int`，包含負數、`int.MinValue`、`int.MaxValue`。**value = -1 也是合法資料**，成功讀取它時仍要更新使用順序。
- 各個快取實例的資料與使用順序互相獨立；不要求執行緒安全。

## 操作範例

```csharp
var cache = new Day008LruCache(2);
cache.Put(1, 1);
cache.Put(2, 2);
cache.Get(1);      // 1，key=1 成為最近使用
cache.Put(3, 3);   // 容量已滿，淘汰 key=2
cache.Get(2);      // -1（找不到）
cache.Put(4, 4);   // 淘汰 key=1
cache.Get(1);      // -1
cache.Get(3);      // 3
cache.Get(4);      // 4
```

**注意**：`Get` 讀到的 key 會改變新舊順序；`Put` **更新既有 key** 也會改變新舊順序。讀取不存在的 key 不會影響淘汰次序。

## 學習目標與複雜度

- Hash Table / `Dictionary<TKey,TValue>` 的查詢特性
- Linked List / 雙向鏈結串列的節點搬移
- 快取淘汰策略、容量邊界、狀態管理
- 目標：`Get` **平均 O(1)**、`Put` **平均 O(1)**，整體額外空間 **O(capacity)**。

提示：單獨使用 `Dictionary` 很容易查值，但要如何快速知道哪個項目最久未使用？單獨使用 `List` 又會遇到什麼成本？

## xUnit 測試

本題提供 **46 個 xUnit 測試案例**：**32 組操作序列**（含 20 組固定種子隨機情境），另有 **14 個額外測試**。涵蓋容量 0、負容量、淘汰順序、更新資料、`-1` 值、整數極限、獨立實例、20,000 筆資料以及不同演算法的慢速 Oracle 交叉驗證。

在 **Repository 根目錄** 執行：

```powershell
dotnet restore .\CSharpDailyAlgorithms.sln
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day008" --nologo
```

**本題故意保留 TODO；完成實作以前測試失敗是預期行為。** 未實際執行測試，不能當作測試成功。

## 本日檔案

- [Day008LruCache.cs](./Day008LruCache.cs)：你的 C# 解答位置
- [Day008LruCacheTests.cs](../../../tests/DailyAlgorithms.Tests/Day008LruCacheTests.cs)：xUnit 測試
- [Day008LruCacheReference.cs](../../../mentor/Day008LruCacheReference.cs)：參考實作，請自行解完再看
- [Day008Review.md](../../../mentor/Day008Review.md)：解題技巧、複雜度與評分檢查表
- [PROGRESS.md](../../../PROGRESS.md)：練習進度與實際測試紀錄

> 每一日的完整題目保留在當日資料夾的 `README.md`，根目錄 README 僅保留題目索引。
