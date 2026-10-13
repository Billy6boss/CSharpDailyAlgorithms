# Day 005（2026-10-12）：Maximum Subarray 最大連續子陣列和

**難度：Medium｜建議時間：20～35 分鐘**

給定 `int[] numbers`，找出總和最大的「連續」子陣列，回傳該總和。非空輸入必須選取至少一個元素；空陣列回傳 0；null 擲出 `ArgumentNullException`，參數名稱為 `numbers`。不得修改輸入。

限制：`0 <= numbers.Length <= 100_000`，元素可以是任何合法 `int`。回傳型別為 `long`，因為總和可能超過 `int` 範圍。

```csharp
Day005MaximumSubarray.Solve([-2, 1, -3, 4, -1, 2, 1, -5, 4]); // 6，區間 [4, -1, 2, 1]
Day005MaximumSubarray.Solve([5, 4, -1, 7, 8]);                // 23
Day005MaximumSubarray.Solve([-5, -2, -9]);                   // -2
Day005MaximumSubarray.Solve([]);                            // 0
Day005MaximumSubarray.Solve([int.MaxValue, int.MaxValue]);   // 4294967294L
```

請完成 `src/DailyAlgorithms/Day005/Day005MaximumSubarray.cs` 的 `public static long Solve(int[] numbers)`。挑戰目標為 **O(n) 時間、O(1) 額外空間**。

提示：假設最佳區間「必須在目前位置結尾」，目前的元素應該延伸前一段，還是重新開始？若全部都是負數，初始化方式會如何影響答案？

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day005"
dotnet test .\CSharpDailyAlgorithms.sln
```

本題包含 **39 個 xUnit 測試**（32 組參數案例與 7 個額外測試），涵蓋邊界、溢位、輸入不變性、重複呼叫、100,000 個元素，以及 1,000 組固定種子隨機輸入對照暴力解法。題目保留 TODO，在完成解答前會有測試失敗。

參考答案與回顧分別放在 `../../../mentor/Day005MaximumSubarrayReference.cs`、`../../../mentor/Day005Review.md`，刻意不編入 Solution。Day 001 的實際解答覆核放在 `mentor/Day001Review_2026-10-12.md`。

---

## 本題檔案

- **C# 練習程式**：[`Day005MaximumSubarray.cs`](./Day005MaximumSubarray.cs)
- **xUnit 單元測試**：[Day005MaximumSubarrayTests.cs](../../../tests/DailyAlgorithms.Tests/Day005MaximumSubarrayTests.cs)
- **參考解答（請完成後再看）**：[Day005MaximumSubarrayReference.cs](../../../mentor/Day005MaximumSubarrayReference.cs)
- **解題檢討**：[Day005Review.md](../../../mentor/Day005Review.md)
- **進度與測試紀錄**：[PROGRESS.md](../../../PROGRESS.md)

在 **Repository 根目錄** 執行本題測試：

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day005"
```

> 練習程式保留你自己的實作或 TODO；參考解答不編入 Solution。未完成 TODO 前的測試失敗屬於預期，請以實際執行結果為準。
