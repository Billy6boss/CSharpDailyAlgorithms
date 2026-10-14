# Day 007｜Number of Islands（島嶼數量）

**日期**：2026-10-14　**難度**：Medium　**建議時間**：30～45 分鐘

## 題目

給定一張以 `char[][] grid` 表示的矩形地圖，每個字元為 `'0'`（海水）或 `'1'`（陸地）。

一座島嶼是上下左右四個方向相鄰、相互連通的一群陸地；**斜角相鄰不算連通**。請計算地圖共有多少座島嶼。函式不可修改原始輸入。

## 方法與輸入／輸出

```csharp
public static int CountIslands(char[][] grid)
```

- **輸入**：包含 `'0'`、`'1'` 的矩形 `char[][]`。
- **輸出**：島嶼數量（`int`），不得修改輸入外層或內層陣列。

## 範例

```csharp
var first = new[]
{
    "11000".ToCharArray(),
    "11000".ToCharArray(),
    "00100".ToCharArray(),
    "00011".ToCharArray()
};
Day007NumberOfIslands.CountIslands(first); // 3

var diagonalOnly = new[]
{
    "10".ToCharArray(),
    "01".ToCharArray()
};
Day007NumberOfIslands.CountIslands(diagonalOnly); // 2

Day007NumberOfIslands.CountIslands([]); // 0
```

注意：`["010", "101", "010"]` 有 **4 座**島嶼，不能將斜角當成連通。

## 限制與邊界情況

- `grid == null`：拋出 `ArgumentNullException`，參數名稱 `grid`。
- 任一內層列是 `null`、各列長度不同（非矩形），或含 `'0'`、`'1'` 之外的字元：拋出 `ArgumentException`。
- 空地圖 `[]` 回傳 **0**；矩形零欄地圖（例如 `[[], []]`）也回傳 **0**。
- 全是海水 → **0**；所有陸地相連 → **1**。
- 測試包括單列連續陸地 **120,000** 格；若使用遞迴 DFS，可能發生 `StackOverflowException`。
- 不得就地將 `'1'` 改成 `'0'`。呼叫前後所有輸入陣列內容都必須維持不變。

## 學習目標

**Graph Traversal（圖形走訪）**、BFS / DFS、Visited、Connected Components、矩形地圖驗證。

目標：**時間 O(rows × cols)**、**額外空間 O(rows × cols)**。

提示：思考在遇到「還沒探索過的陸地」時，如何找出同一座島的其他陸地，並確保不會重複計數。避免深度過大的遞迴呼叫。

## 測試方式

本題附 **32 組資料驅動測試 + 8 個額外測試，共 40 個 xUnit 測試案例**。涵蓋輸入驗證、對角線、不可變性、大型地圖，以及 **400 組固定種子隨機測試**（以 Union-Find 獨立比對）。

於 **Repository 根目錄** 執行：

```powershell
dotnet test .\CSharpDailyAlgorithms.sln --filter "FullyQualifiedName~Day007" --nologo
```

未完成 TODO 前的測試失敗是預期結果；**不得將新增測試等同測試通過**。

## 本日檔案

- [題目程式 Day007NumberOfIslands.cs](./Day007NumberOfIslands.cs) — 請在 TODO 實作。
- [單元測試 Day007NumberOfIslandsTests.cs](../../../tests/DailyAlgorithms.Tests/Day007NumberOfIslandsTests.cs)。
- [參考解答 Day007NumberOfIslandsReference.cs](../../../mentor/Day007NumberOfIslandsReference.cs) — 解完再看。
- [檢討 Day007Review.md](../../../mentor/Day007Review.md)。
- [學習進度 PROGRESS.md](../../../PROGRESS.md)。
