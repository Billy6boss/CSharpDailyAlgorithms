# Day 004（2026-10-12）：Longest Substring Without Repeating Characters 最長不重複字元子字串

**難度：Medium**

給定字串 `text`，回傳不含重複 `char` 的最長**連續子字串**長度。空字串回傳 `0`；null 擲出 `ArgumentNullException`；區分大小寫，不做正規化。字元以 C# `char`（UTF-16 code unit）為單位，不按 `Rune` 或文字元素計算。

請完成 `src/DailyAlgorithms/Day004/Day004LongestUniqueSubstring.cs`：

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

本題包含 **34 個 xUnit 測試**，其中有 400 組固定種子隨機輸入比對。題目保留 TODO，完成後再參考 `../../../mentor/Day004LongestUniqueSubstringReference.cs` 與 `../../../mentor/Day004Review.md`；mentor 程式不編入 Solution。

---

## 本題檔案

- **C# 練習程式**：[`Day004LongestUniqueSubstring.cs`](./Day004LongestUniqueSubstring.cs)
- **xUnit 單元測試**：[Day004LongestUniqueSubstringTests.cs](../../../tests/DailyAlgorithms.Tests/Day004LongestUniqueSubstringTests.cs)
- **參考解答（請完成後再看）**：[Day004LongestUniqueSubstringReference.cs](../../../mentor/Day004LongestUniqueSubstringReference.cs)
- **解題檢討**：[Day004Review.md](../../../mentor/Day004Review.md)
- **進度與測試紀錄**：[PROGRESS.md](../../../PROGRESS.md)

在 **Repository 根目錄** 執行本題測試：

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day004"
```

> 練習程式保留你自己的實作或 TODO；參考解答不編入 Solution。未完成 TODO 前的測試失敗屬於預期，請以實際執行結果為準。
