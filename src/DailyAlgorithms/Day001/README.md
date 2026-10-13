# Day 001（2026-10-09）：Two Sum 兩數之和

**難度：Easy（推薦時間 15–25 分鐘）**

給定整數陣列 `numbers` 和整數 `target`，找出 **兩個不同位置**，使 `numbers[i] + numbers[j] == target`。回傳任一組合法索引 `[i, j]`（需滿足 `i < j`）；如果沒有答案，回傳空陣列。不得修改輸入陣列。若 `numbers` 是 `null`，請擲出 `ArgumentNullException`。

請完成：

```csharp
public static int[] Solve(int[] numbers, int target)
```

範例：

```text
numbers = [2, 7, 11, 15], target = 9  -> [0, 1]
numbers = [3, 3], target = 6          -> [0, 1]
numbers = [1, 2, 3], target = 10      -> []
```

限制：`0 <= numbers.Length <= 100_000`、元素與 `target` 都是合法的 `int`。不保證有解，也可能有多組解。

**學習目標**：Hash Table、時間／空間複雜度、重複元素、邊界條件與 `int` 溢位。

## 建議解題流程

1. 打開 `src/DailyAlgorithms/Day001/Day001TwoSum.cs`，替換 `throw new NotImplementedException(...)`。
2. 直接執行 `dotnet test`。在你實作之前，測試會「預期失敗」，這是刻意設計的 TDD 起始狀態。
3. 先追求正確，再優化到平均 **O(n)** 時間。卡住時可先嘗試 O(n²) 版本。
4. 完成後再打開 `../../../mentor/Day001TwoSumReference.cs`（與 `../../../mentor/Day001Review.md`），比較是否存在更好的寫法。參考程式刻意不會編入 Solution。

---

## 本題檔案

- **C# 練習程式**：[`Day001TwoSum.cs`](./Day001TwoSum.cs)
- **xUnit 單元測試**：[Day001TwoSumTests.cs](../../../tests/DailyAlgorithms.Tests/Day001TwoSumTests.cs)
- **參考解答（請完成後再看）**：[Day001TwoSumReference.cs](../../../mentor/Day001TwoSumReference.cs)
- **解題檢討**：[Day001Review.md](../../../mentor/Day001Review.md)
- **進度與測試紀錄**：[PROGRESS.md](../../../PROGRESS.md)

在 **Repository 根目錄** 執行本題測試：

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day001"
```

> 練習程式保留你自己的實作或 TODO；參考解答不編入 Solution。未完成 TODO 前的測試失敗屬於預期，請以實際執行結果為準。
