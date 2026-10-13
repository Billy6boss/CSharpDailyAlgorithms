# Day 002（2026-10-10）：Valid Parentheses 有效括號

**難度：Easy**

給定字串 `brackets`，判斷 `()`、`[]`、`{}` 是否正確配對與巢狀。空字串回傳 `true`；包含任何非括號字元時回傳 `false`；null 擲出 `ArgumentNullException`。

請完成 `src/DailyAlgorithms/Day002/Day002ValidParentheses.cs`：

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

本題包含 **25 個 xUnit 測試**。2026-10-13 使用者實作已通過 25/25 測試；本次實作評價與改進提示請見 [Day002Review_2026-10-13.md](../../../mentor/Day002Review_2026-10-13.md)。參考解答及一般解題回顧分別在 `../../../mentor/Day002ValidParenthesesReference.cs` 與 `../../../mentor/Day002Review.md`；mentor 程式不編入 Solution。

---

## 本題檔案

- **C# 練習程式**：[`Day002ValidParentheses.cs`](./Day002ValidParentheses.cs)
- **xUnit 單元測試**：[Day002ValidParenthesesTests.cs](../../../tests/DailyAlgorithms.Tests/Day002ValidParenthesesTests.cs)
- **參考解答（請完成後再看）**：[Day002ValidParenthesesReference.cs](../../../mentor/Day002ValidParenthesesReference.cs)
- **解題檢討**：[Day002Review.md](../../../mentor/Day002Review.md)
- **本次實作評價（僅提示）**：[Day002Review_2026-10-13.md](../../../mentor/Day002Review_2026-10-13.md)
- **進度與測試紀錄**：[PROGRESS.md](../../../PROGRESS.md)

在 **Repository 根目錄** 執行本題測試：

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day002"
```

> 練習程式保留你自己的實作或 TODO；參考解答不編入 Solution。未完成 TODO 前的測試失敗屬於預期，請以實際執行結果為準。
