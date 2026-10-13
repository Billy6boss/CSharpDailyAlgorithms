# C# 每日演算法練習

使用 **.NET 8 / C# 12 / xUnit** 的可累積題庫。每一天都有專屬資料夾，**題目程式與 `README.md` 放在一起**；根目錄 README 只提供專案入口與索引，不再堆疊每天的完整題目。

## 快速開始

在 Windows 11／JetBrains Rider 開啟 `CSharpDailyAlgorithms.sln`，確認已安裝 .NET 8 SDK。

```powershell
git pull --ff-only origin master
dotnet restore .\CSharpDailyAlgorithms.sln
dotnet test .\CSharpDailyAlgorithms.sln
```

你可以在 Rider 內直接開啟對應的題目與測試。**尚未完成的 TODO 會造成測試失敗**；不代表原本已解完的題目失效。

## 題目索引

| 日期 | 題目 | 學習重點 |
| --- | --- | --- |
| 2026-10-09 | [Day 001：Two Sum（兩數之和）](src/DailyAlgorithms/Day001/README.md) | Hash Table |
| 2026-10-10 | [Day 002：Valid Parentheses（有效括號）](src/DailyAlgorithms/Day002/README.md) | Stack |
| 2026-10-11 | [Day 003：Binary Search（二分搜尋）](src/DailyAlgorithms/Day003/README.md) | Binary Search |
| 2026-10-12 | [Day 004：Longest Unique Substring（最長不重複子字串）](src/DailyAlgorithms/Day004/README.md) | Sliding Window |
| 2026-10-12 | [Day 005：Maximum Subarray（最大連續子陣列和）](src/DailyAlgorithms/Day005/README.md) | Dynamic Programming |
| 2026-10-13 | [Day 006：Merge Intervals（合併區間）](src/DailyAlgorithms/Day006/README.md) | Sorting + Greedy |

## 每日資料夾規範

```text
src/DailyAlgorithms/
  DailyAlgorithms.csproj
  Day001/
    README.md                 # 本日題目與範例
    Day001TwoSum.cs           # 實作（保留你的答案）
  Day002/
    README.md
    Day002ValidParentheses.cs
  ...
  Day006/
    README.md
    Day006MergeIntervals.cs
tests/DailyAlgorithms.Tests/
  Day001TwoSumTests.cs         # 單元測試由獨立 xUnit 專案管理
  ...
mentor/                        # 參考解答與檢討，並未編入 Solution
PROGRESS.md                    # 學習進度和實際測試紀錄
```

每新增一題，都以 `src/DailyAlgorithms/DayNNN/` 建立新的 `README.md` 與 `DayNNN題目.cs`；測試檔放在 `tests/DailyAlgorithms.Tests/`，參考解答放在 `mentor/`。每題 README 應有 **題目敘述、輸入／輸出、範例、限制與邊界條件、學習目標、測試指令、相關檔案連結**。

## 解題與 Code Review

1. 點選上方題目索引，閱讀當日 `README.md`，再實作 C# TODO。
2. 執行對應 Day 的 `dotnet test`；先求正確，再分析時間／空間複雜度。
3. 完成後將答案 Commit／Push，再做 100 分制程式碼評價（正確性 40、效能 30、可讀性 20、測試 10）。
4. 每日新題目應另開分支與 PR；**不得覆寫既有答案**。參考解答留在 `mentor/`，請完成後再看。

詳見 [PROGRESS.md](PROGRESS.md) 的測試紀錄。
