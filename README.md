# C# 每日演算法練習

使用 **.NET 8 / C# 12 / xUnit** 累積每日 C# 演算法題庫。每一天的題目完整敘述放在其專屬 `src/DailyAlgorithms/DayNNN/README.md`，學生程式保留 TODO；參考答案放在不參與編譯的 `mentor/`。

## 使用方式

在 Windows／JetBrains Rider 開啟 `CSharpDailyAlgorithms.sln`，需安裝 .NET 8 SDK。

```powershell
git pull --ff-only origin master
dotnet restore .\CSharpDailyAlgorithms.sln
dotnet test .\CSharpDailyAlgorithms.sln
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day009"
```

新題的 TODO 會造成預期中的測試失敗，並不代表舊題答案失效。請先實作、測試，再查看 mentor 的參考答案。進度與真實測試狀態詳見 [PROGRESS.md](PROGRESS.md)。每日新題透過 PR 供審核，不直接覆寫既有作答。

## 每日題目索引

| 日期（台灣） | 題目 README | 學習主題 |
| --- | --- | --- |
| 2026-10-09 | [Day 001：Two Sum（兩數之和）](src/DailyAlgorithms/Day001/README.md) | Hash Table |
| 2026-10-10 | [Day 002：Valid Parentheses（有效括號）](src/DailyAlgorithms/Day002/README.md) | Stack |
| 2026-10-11 | [Day 003：Binary Search（二分搜尋）](src/DailyAlgorithms/Day003/README.md) | Binary Search |
| 2026-10-12 | [Day 004：Longest Unique Substring（最長不重複子字串）](src/DailyAlgorithms/Day004/README.md) | Sliding Window |
| 2026-10-12 | [Day 005：Maximum Subarray（最大連續子陣列和）](src/DailyAlgorithms/Day005/README.md) | Dynamic Programming |
| 2026-10-13 | [Day 006：Merge Intervals（合併區間）](src/DailyAlgorithms/Day006/README.md) | Sorting + Greedy |
| 2026-10-14 | [Day 007：Number of Islands（島嶼數量）](src/DailyAlgorithms/Day007/README.md) | BFS / DFS |
| 2026-10-15（待合併） | [Day 008：LRU Cache（最近最少使用快取）— PR #4](https://github.com/Billy6boss/CSharpDailyAlgorithms/pull/4) | Hash Table + Doubly Linked List |
| 2026-11-03 | [Day 009：Sliding Window Maximum（滑動視窗最大值）](src/DailyAlgorithms/Day009/README.md) | Monotonic Deque |
