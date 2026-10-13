# C# 每日演算法練習（可持續沿用）

這是一份給 C#/.NET 開發者的 **可累積題庫**：每日題目實作在 `src/`，xUnit 單元測試放 `tests/`，不同日期直接新增類別與測試即可，不需要每天重建專案。

## 第一次設定（Windows 11 / Rider / Visual Studio / 命令列）

1. 安裝 **.NET 8 SDK**（不是只有 Runtime），並確認 `dotnet --version` 能執行。
2. 將整包 ZIP 解壓縮，並在解壓縮後的根目錄開啟 `CSharpDailyAlgorithms.sln`。
3. 執行：

```powershell
dotnet restore .\CSharpDailyAlgorithms.sln
dotnet test .\CSharpDailyAlgorithms.sln
```

也可直接執行 `powershell -ExecutionPolicy Bypass -File .\scripts\Run-Tests.ps1`，或在 Rider 的 Unit Tests 視窗執行。

**注意**：第一次還原 xUnit 套件需要可連接 NuGet.org 的網路。原始 ZIP 製作時的環境沒有安裝 .NET SDK，因此當時未驗證執行結果；目前專案的本機驗證記錄請見 [PROGRESS.md](PROGRESS.md)。尚未完成的題目保留 TODO，對應測試會失敗；新增題目檔案不代表測試已通過。

## Day 001（2026-10-09）：Two Sum 兩數之和

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

1. 打開 `src/DailyAlgorithms/Day001TwoSum.cs`，替換 `throw new NotImplementedException(...)`。
2. 直接執行 `dotnet test`。在你實作之前，測試會「預期失敗」，這是刻意設計的 TDD 起始狀態。
3. 先追求正確，再優化到平均 **O(n)** 時間。卡住時可先嘗試 O(n²) 版本。
4. 完成後再打開 `mentor/Day001TwoSumReference.cs`（與 `mentor/Day001Review.md`），比較是否存在更好的寫法。參考程式刻意不會編入 Solution。

## 檔案結構

```text
CSharpDailyAlgorithms.sln
src/DailyAlgorithms/Day001TwoSum.cs
src/DailyAlgorithms/Day002ValidParentheses.cs
src/DailyAlgorithms/Day003BinarySearch.cs
src/DailyAlgorithms/Day004LongestUniqueSubstring.cs
src/DailyAlgorithms/Day005MaximumSubarray.cs
src/DailyAlgorithms/DailyAlgorithms.csproj
tests/DailyAlgorithms.Tests/Day001TwoSumTests.cs
tests/DailyAlgorithms.Tests/Day002ValidParenthesesTests.cs
tests/DailyAlgorithms.Tests/Day003BinarySearchTests.cs
tests/DailyAlgorithms.Tests/Day004LongestUniqueSubstringTests.cs
tests/DailyAlgorithms.Tests/Day005MaximumSubarrayTests.cs
tests/DailyAlgorithms.Tests/DailyAlgorithms.Tests.csproj
mentor/Day001TwoSumReference.cs
mentor/Day001Review.md
mentor/Day001Review_2026-10-12.md
mentor/Day002ValidParenthesesReference.cs
mentor/Day002Review.md
mentor/Day003BinarySearchReference.cs
mentor/Day003Review.md
mentor/Day004LongestUniqueSubstringReference.cs
mentor/Day004Review.md
mentor/Day005MaximumSubarrayReference.cs
mentor/Day005Review.md
PROGRESS.md
scripts/Run-Tests.ps1
```

## 接下來的每日練習

新題目一律沿用這個 Solution，增加 `DayNNN題目.cs` 與相應 xUnit 測試檔。題目檔不包含答案；解出後使用測試驗證，再參考 `mentor/` 的最佳化方向。要評價**你自己的**程式碼，仍需提供實際程式碼與測試輸出。

## Day 002（2026-10-10）：Valid Parentheses 有效括號

**難度：Easy**

給定字串 `brackets`，判斷 `()`、`[]`、`{}` 是否正確配對與巢狀。空字串回傳 `true`；包含任何非括號字元時回傳 `false`；null 擲出 `ArgumentNullException`。

請完成 `src/DailyAlgorithms/Day002ValidParentheses.cs`：

```csharp
public static bool IsValid(string brackets)
```

範例：

```text
"()[]{}" -> true
"{[()]}" -> true
"([)]"   -> false
"(()"    -> false
""       -> true
"a"      -> false
```

**學習目標**：Stack、括號配對、巢狀順序與邊界條件。挑戰目標為 **O(n) 時間、O(n) 最壞額外空間**。

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day002"
```

本題包含 **25 個 xUnit 測試**。題目保留 TODO，完成後再參考 `mentor/Day002ValidParenthesesReference.cs` 與 `mentor/Day002Review.md`；mentor 程式不編入 Solution。

## Day 003（2026-10-11）：Binary Search 二分搜尋

**難度：Easy**

給定已依非遞減順序排列的整數陣列 `numbers` 和整數 `target`，回傳目標值**第一次出現**的索引。找不到或陣列為空時回傳 `-1`；null 擲出 `ArgumentNullException`。不得修改輸入陣列。

請完成 `src/DailyAlgorithms/Day003BinarySearch.cs`：

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

本題包含 **29 個 xUnit 測試**，其中有 250 組固定種子隨機輸入比對。題目保留 TODO，完成後再參考 `mentor/Day003BinarySearchReference.cs` 與 `mentor/Day003Review.md`；mentor 程式不編入 Solution。

## Day 004（2026-10-12）：Longest Substring Without Repeating Characters 最長不重複字元子字串

**難度：Medium**

給定字串 `text`，回傳不含重複 `char` 的最長**連續子字串**長度。空字串回傳 `0`；null 擲出 `ArgumentNullException`；區分大小寫，不做正規化。字元以 C# `char`（UTF-16 code unit）為單位，不按 `Rune` 或文字元素計算。

請完成 `src/DailyAlgorithms/Day004LongestUniqueSubstring.cs`：

```csharp
public static int LengthOfLongestSubstring(string text)
```

範例：

```text
"abcabcbb" -> 3
"pwwkew"   -> 3
"abba"     -> 2
"aA"       -> 2
""         -> 0
```

**學習目標**：滑動視窗、`Dictionary<char, int>`、重複字元位置與視窗左界。挑戰目標為 **平均 O(n) 時間、O(min(n, 字元種類數)) 額外空間**。

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day004"
```

本題包含 **34 個 xUnit 測試**，其中有 400 組固定種子隨機輸入比對。題目保留 TODO，完成後再參考 `mentor/Day004LongestUniqueSubstringReference.cs` 與 `mentor/Day004Review.md`；mentor 程式不編入 Solution。

## Day 005（2026-10-12）：Maximum Subarray 最大連續子陣列和

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

請完成 `src/DailyAlgorithms/Day005MaximumSubarray.cs` 的 `public static long Solve(int[] numbers)`。挑戰目標為 **O(n) 時間、O(1) 額外空間**。

提示：假設最佳區間「必須在目前位置結尾」，目前的元素應該延伸前一段，還是重新開始？若全部都是負數，初始化方式會如何影響答案？

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day005"
dotnet test .\CSharpDailyAlgorithms.sln
```

本題包含 **39 個 xUnit 測試**（32 組參數案例與 7 個額外測試），涵蓋邊界、溢位、輸入不變性、重複呼叫、100,000 個元素，以及 1,000 組固定種子隨機輸入對照暴力解法。題目保留 TODO，在完成解答前會有測試失敗。

參考答案與回顧分別放在 `mentor/Day005MaximumSubarrayReference.cs`、`mentor/Day005Review.md`，刻意不編入 Solution。Day 001 的實際解答覆核放在 `mentor/Day001Review_2026-10-12.md`。

2026-10-13 已將 Day 002～004 的 12 個題目、測試與 mentor 檔案匯入本專案，現在包含 Day 001～005。Day 002～004 沿用下載包的 TODO 練習；既有解答及專案設定均保留。
