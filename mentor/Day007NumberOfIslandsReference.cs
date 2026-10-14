// Reference implementation only. The mentor directory is not compiled into the solution.
using System;
using System.Collections.Generic;

namespace DailyAlgorithms.Mentor;

public static class Day007NumberOfIslandsReference
{
    private static readonly (int RowOffset, int ColumnOffset)[] Directions =
    [
        (-1, 0), (1, 0), (0, -1), (0, 1)
    ];

    public static int CountIslands(char[][] grid)
    {
        ArgumentNullException.ThrowIfNull(grid);
        var rows = grid.Length;
        if (rows == 0) return 0;

        if (grid[0] is null)
            throw new ArgumentException("Rows cannot be null.", nameof(grid));

        var columns = grid[0].Length;
        for (var row = 0; row < rows; row++)
        {
            if (grid[row] is null || grid[row].Length != columns)
                throw new ArgumentException("Grid must be rectangular.", nameof(grid));

            for (var column = 0; column < columns; column++)
                if (grid[row][column] is not ('0' or '1'))
                    throw new ArgumentException("Only '0' or '1' is allowed.", nameof(grid));
        }

        if (columns == 0) return 0;

        var visited = new bool[rows, columns];
        var pending = new Queue<(int Row, int Column)>();
        var count = 0;

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                if (grid[row][column] != '1' || visited[row, column])
                    continue;

                count++;
                visited[row, column] = true;
                pending.Enqueue((row, column));

                while (pending.Count > 0)
                {
                    var (currentRow, currentColumn) = pending.Dequeue();
                    foreach (var (rowOffset, columnOffset) in Directions)
                    {
                        var nextRow = currentRow + rowOffset;
                        var nextColumn = currentColumn + columnOffset;
                        if (nextRow < 0 || nextRow >= rows ||
                            nextColumn < 0 || nextColumn >= columns ||
                            visited[nextRow, nextColumn] ||
                            grid[nextRow][nextColumn] != '1')
                            continue;

                        visited[nextRow, nextColumn] = true;
                        pending.Enqueue((nextRow, nextColumn));
                    }
                }
            }
        }

        return count;
    }
}
