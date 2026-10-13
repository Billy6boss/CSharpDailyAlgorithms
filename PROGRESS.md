# 每日 C# 演算法練習進度

| 日期（台灣） | 題號 | 題目 | 狀態 | 測試結果 | 程式碼評價 |
| --- | --- | --- | --- | --- | --- |
| 2026-10-09 | 001 | Two Sum 兩數之和 | 已實作 | 13/13 通過（2026-10-13 本機實測） | 97/100；詳見 mentor/Day001Review_2026-10-12.md |
| 2026-10-10 | 002 | Valid Parentheses 有效括號 | 待作答（TODO） | 0/25 通過、25 失敗（2026-10-13 本機實測） | 完成後評分 |
| 2026-10-11 | 003 | Binary Search 二分搜尋 | 待作答（TODO） | 1/29 通過、28 失敗（2026-10-13 本機實測） | 完成後評分 |
| 2026-10-12 | 004 | Longest Substring Without Repeating Characters 最長不重複字元子字串 | 待作答（TODO） | 1/34 通過、33 失敗（2026-10-13 本機實測） | 完成後評分 |
| 2026-10-12 | 005 | Maximum Subarray 最大連續子陣列和 | 待作答（TODO） | 1/39 通過、38 失敗（2026-10-13 本機實測）；參考答案 39/39 通過（先前工作副本） | 完成後評分 |\n| 2026-10-13 | 006 | Merge Intervals 合併區間 | 待作答（TODO） | 尚未執行 Day 006 的 xUnit 測試；待實測 | 完成後評價 |

> 將新題目新增在 `src/DailyAlgorithms/DayNNN*.cs`，並於 `tests/DailyAlgorithms.Tests/` 新增對應的測試檔，即可沿用同一個 Solution。

2026-10-13：已從下載的 `CSharpDailyAlgorithms_Days002-004_OnlyNewFiles_2026-10-12` 更新包匯入 Day 002～004 的 12 個題目、測試與 mentor 檔案；各檔 SHA256 與下載包一致，既有 Day 001、Day 005 與專案設定保留。

本機驗證：`dotnet build .\CSharpDailyAlgorithms.sln --no-restore --nologo` 成功，0 警告、0 錯誤。完整測試共 140 個，16 通過、124 失敗、0 略過；所有失敗均為待作答 TODO 擲出的 `NotImplementedException`，沒有其他失敗。
