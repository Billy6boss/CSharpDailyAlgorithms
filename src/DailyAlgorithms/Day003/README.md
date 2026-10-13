# Day 003（2026-10-11）：Binary Search 二分搜尋

**難度：Easy**

給定已依非遞減順序排列的整數陣列 `numbers` 和整數 `target`，回傳目標值**第一次出現**的索引。找不到或陣列為空時回傳 `-1`；null 擲出 `ArgumentNullException`。不得修改輸入陣列。

請完成 `src/DailyAlgorithms/Day003/Day003BinarySearch.cs`：

```csharp
public static int FindFirstIndex(int[] numbers, int target)
```

範例：

```text
numbers = [-3, -1, 2, 2, 2, 9], target = 2 -> 2
numbers = [1, 1, 1], target = 1             -> 0
numbers = [1, 3, 5], target = 2             -> -1
numbers = [], target = 1                    -> -1
```

**學習目標**：二分搜尋、搜尋區間、重複元素與索引邊界。挑戰目標為 **O(log n) 時間、O(1) 額外空間**。

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day003"
```

本題包含 **29 個 xUnit 測試**，其中有 250 組固定種子隨機輸入比對。題目保留 TODO，完成後再參考 `../../../mentor/Day003BinarySearchReference.cs` 與 `../../../mentor/Day003Review.md`；mentor 程式不編入 Solution。

---

## 本題檔案

- **C# 練習程式**：[`Day003BinarySearch.cs`](./Day003BinarySearch.cs)
- **xUnit 單元測試**：[Day003BinarySearchTests.cs](../../../tests/DailyAlgorithms.Tests/Day003BinarySearchTests.cs)
- **參考解答（請完成後再看）**：[Day003BinarySearchReference.cs](../../../mentor/Day003BinarySearchReference.cs)
- **解題檢討**：[Day003Review.md](../../../mentor/Day003Review.md)
- **進度與測試紀錄**：[PROGRESS.md](../../../PROGRESS.md)

在 **Repository 根目錄** 執行本題測試：

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day003"
```

> 練習程式保留你自己的實作或 TODO；參考解答不編入 Solution。未完成 TODO 前的測試失敗屬於預期，請以實際執行結果為準。
