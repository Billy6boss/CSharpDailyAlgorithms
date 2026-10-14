# 每日 C# 演算法練習進度

| 日期（台灣） | 題號 | 題目 | 狀態 | 測試結果 | 程式碼評價 |
| --- | --- | --- | --- | --- | --- |
| 2026-10-09 | 001 | [Two Sum（兩數之和）](src/DailyAlgorithms/Day001/README.md) | 已實作 | 13/13 通過（2026-10-13 本機實測） | 97/100；詳見 mentor/Day001Review_2026-10-12.md |
| 2026-10-10 | 002 | [Valid Parentheses（有效括號）](src/DailyAlgorithms/Day002/README.md) | 已實作 | 修正後 25/25 通過（2026-10-13 本機實測） | 97/100；詳見 mentor/Day002Review_2026-10-13.md（僅提示） |
| 2026-10-11 | 003 | [Binary Search（二分搜尋）](src/DailyAlgorithms/Day003/README.md) | 待作答（TODO） | 1/29 通過、28 失敗（2026-10-13 本機實測） | 完成後評分 |
| 2026-10-12 | 004 | [Longest Unique Substring（最長不重複子字串）](src/DailyAlgorithms/Day004/README.md) | 待作答（TODO） | 1/34 通過、33 失敗（2026-10-13 本機實測） | 完成後評分 |
| 2026-10-12 | 005 | [Maximum Subarray（最大連續子陣列和）](src/DailyAlgorithms/Day005/README.md) | 待作答（TODO） | 1/39 通過、38 失敗（2026-10-13 本機實測）；參考答案 39/39 通過（先前工作副本） | 完成後評分 |
| 2026-10-13 | 006 | [Merge Intervals（合併區間）](src/DailyAlgorithms/Day006/README.md) | 待作答（TODO） | 尚未執行 Day 006 的 xUnit 測試；待實測 | 完成後評價 |
| 2026-10-14 | 007 | [Number of Islands（島嶼數量）](src/DailyAlgorithms/Day007/README.md) | 待作答（TODO） | 尚未執行 dotnet test（目前環境未安裝 .NET SDK） | 完成後評分 |

> 將新題目放在 `src/DailyAlgorithms/DayNNN/`，同一資料夾建立 `README.md` 與 `DayNNN題目.cs`；於 `tests/DailyAlgorithms.Tests/` 新增單元測試。根目錄 README 僅保留索引。

2026-10-13：已從下載的 `CSharpDailyAlgorithms_Days002-004_OnlyNewFiles_2026-10-12` 更新包匯入 Day 002～004 的 12 個題目、測試與 mentor 檔案；各檔 SHA256 與下載包一致，既有 Day 001、Day 005 與專案設定保留。

匯入時本機驗證（Day 002 完成前）：`dotnet build .\CSharpDailyAlgorithms.sln --no-restore --nologo` 成功，0 警告、0 錯誤。當時完整測試共 140 個，16 通過、124 失敗、0 略過；所有失敗均為待作答 TODO 擲出的 `NotImplementedException`，沒有其他失敗。

2026-10-13：Day 002 使用者實作初次覆核為 96/100；同日簡單修正後重新執行 25 個 xUnit 測試，全部通過，最新評價 97/100。改進方向以提示記錄於 `mentor/Day002Review_2026-10-13.md`，解答保持原樣。本次僅執行 Day 002 測試，其他題目的紀錄沿用各自最近一次驗證。
