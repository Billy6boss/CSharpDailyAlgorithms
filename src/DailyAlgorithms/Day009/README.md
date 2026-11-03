# Day 009｜Sliding Window Maximum（滑動視窗最大值）

**日期**：2026-11-03（台灣）　**難度**：Hard　**建議時間**：40～60 分鐘

## 題目敘述

給定整數陣列 `nums` 和固定寬度 `k` 的**連續視窗**。視窗起初覆蓋 `nums[0..k-1]`，每次向右移動**一格**直到陣列結尾。請依照視窗的出現順序，回傳**每個視窗內的最大值**。

請實作下列方法，不可以修改原輸入：

```csharp
public static int[] MaxSlidingWindow(int[] nums, int k)
```

## 輸入與輸出

- 輸入：`nums`（`int[]`，允許正、負數及重複值）、`k`（視窗大小）。
- 輸出：新的 `int[]`，長度為 `nums.Length - k + 1`；第 `i` 個值是 `nums[i..i+k-1]` 的最大元素。
- `nums == null`：擲出 `ArgumentNullException`，參數名稱 `nums`。
- `k <= 0` 或 `k > nums.Length`：擲出 `ArgumentOutOfRangeException`，參數名稱 `k`。空陣列也沒有合法視窗。
- 不得修改 `nums`；包括 `k == 1` 時，也應回傳新的獨立陣列，而不是直接回傳原參考。

## 範例

```csharp
int[] nums = [1, 3, -1, -3, 5, 3, 6, 7];
Day009SlidingWindowMaximum.MaxSlidingWindow(nums, 3);
// [3, 3, 5, 5, 6, 7]

Day009SlidingWindowMaximum.MaxSlidingWindow([4, -2], 2); // [4]
Day009SlidingWindowMaximum.MaxSlidingWindow([-3, -1, -5], 1); // [-3, -1, -5]
Day009SlidingWindowMaximum.MaxSlidingWindow([2, 2, 2], 2); // [2, 2]
```

第一例視窗依序為 `[1,3,-1]`、`[3,-1,-3]`、`[-1,-3,5]`、`[-3,5,3]`、`[5,3,6]`、`[3,6,7]`。

## 限制與邊界

- 有效輸入：`1 <= nums.Length <= 100_000`，`1 <= k <= nums.Length`。
- 每個元素可以是任何 C# `int`，包含 `int.MinValue`、`int.MaxValue`，也可能全部是負數。
- 需處理 `k == 1`、`k == nums.Length`、同值重複、最大值離開視窗、嚴格遞增與遞減。
- 不應保存跨呼叫共用的可變狀態；不要求執行緒安全。

## 學習主題與複雜度目標

- Sliding Window（滑動視窗）、Monotonic Deque（單調雙端佇列）。
- 練習用**索引**追蹤候選最大值，以及如何排除不可能再成為最大值的候選。
- **時間目標：均攤 O(n)**。重新掃描每個視窗得到的 O(n × k) 不符合效能目標。
- **額外空間目標：O(k)**（不計輸出陣列 `O(n-k+1)`）。

提示：想一想新元素進入後，原本更小而且更舊的元素有沒有可能在未來再次成為最大值？每個索引最多加入、移除一次。

## 測試方式

本日提供 **70 組 xUnit 測試案例**：**50 組資料驅動測試**（26 組手動預期值＋24 組固定種子隨機資料）以及 **20 組專項測試**。涵蓋不合法參數、輸入不可變、極端整數、數萬筆連續資料及 300 組隨機資料與獨立慢速 Oracle 的交叉驗證。

在 Repository 根目錄執行：

```powershell
dotnet restore .\CSharpDailyAlgorithms.sln
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day009" --nologo
```

**新增的學生程式刻意保留 TODO；作答前正常輸入會拋出 `NotImplementedException`，因此預期部分測試失敗。不代表專案既有已解題目失效。** 只有真的跑過測試，才可以紀錄通過數。

## 相關連結

- [Day009SlidingWindowMaximum.cs](./Day009SlidingWindowMaximum.cs) — 待你實作的 TODO
- [Day009SlidingWindowMaximumTests.cs](../../../tests/DailyAlgorithms.Tests/Day009SlidingWindowMaximumTests.cs) — xUnit 測試
- [Day009SlidingWindowMaximumReference.cs](../../../mentor/Day009SlidingWindowMaximumReference.cs) — 獨立參考答案（解完再看）
- [Day009Review.md](../../../mentor/Day009Review.md) — 解題後檢討
- [PROGRESS.md](../../../PROGRESS.md) — 進度與測試紀錄
- [LeetCode 239 — Sliding Window Maximum](https://leetcode.com/problems/sliding-window-maximum/) — 延伸參考題
