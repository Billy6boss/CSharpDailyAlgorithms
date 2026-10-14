using DailyAlgorithms;
using Xunit;

namespace DailyAlgorithms.Tests;

public sealed class Day007NumberOfIslandsTests
{
    private static char[][] Grid(params string[] rows) =>
        rows.Select(value => value.ToCharArray()).ToArray();

    public static IEnumerable<object[]> Examples()
    {
        yield return new object[] { Grid(), 0 };
        yield return new object[] { Grid(""), 0 };
        yield return new object[] { Grid("", ""), 0 };
        yield return new object[] { Grid("0"), 0 };
        yield return new object[] { Grid("1"), 1 };
        yield return new object[] { Grid("00", "00"), 0 };
        yield return new object[] { Grid("11", "11"), 1 };
        yield return new object[] { Grid("10", "00"), 1 };
        yield return new object[] { Grid("01", "00"), 1 };
        yield return new object[] { Grid("00", "10"), 1 };
        yield return new object[] { Grid("00", "01"), 1 };
        yield return new object[] { Grid("10", "01"), 2 };
        yield return new object[] { Grid("01", "10"), 2 };
        yield return new object[] { Grid("101"), 2 };
        yield return new object[] { Grid("111"), 1 };
        yield return new object[] { Grid("10001"), 2 };
        yield return new object[] { Grid("010", "101", "010"), 4 };
        yield return new object[] { Grid("111", "000", "111"), 2 };
        yield return new object[] { Grid("111", "010", "010"), 1 };
        yield return new object[] { Grid("100", "010", "001"), 3 };
        yield return new object[] { Grid("101", "010", "101"), 5 };
        yield return new object[] { Grid("1100", "1100", "0011", "0011"), 2 };
        yield return new object[] { Grid("11000", "11000", "00100", "00011"), 3 };
        yield return new object[] { Grid("11110", "11010", "11000", "00000"), 1 };
        yield return new object[] { Grid("11111", "10001", "10101", "10001", "11111"), 2 };
        yield return new object[] { Grid("1111", "1001", "1001", "1111"), 1 };
        yield return new object[] { Grid("1001", "1001", "0000", "1001"), 4 };
        yield return new object[] { Grid("10000", "11000", "01100", "00110", "00011"), 1 };
        yield return new object[] { Grid("11100", "00100", "00111"), 1 };
        yield return new object[] { Grid("110011", "000000", "110011"), 4 };
        yield return new object[] { Grid("10101", "10101"), 3 };
        yield return new object[] { Grid("01010", "10101"), 5 };
    }

    [Theory]
    [MemberData(nameof(Examples))]
    public void Examples_ReturnCorrectCount(char[][] grid, int expected)
    {
        Assert.Equal(expected, Day007NumberOfIslands.CountIslands(grid));
    }

    [Fact]
    public void NullGrid_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(
            () => Day007NumberOfIslands.CountIslands(null!));
        Assert.Equal("grid", exception.ParamName);
    }

    [Fact]
    public void NullRow_ThrowsArgumentException()
    {
        char[][] grid = [new[] { '1' }, null!];
        Assert.Throws<ArgumentException>(() => Day007NumberOfIslands.CountIslands(grid));
    }

    [Fact]
    public void JaggedInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => Day007NumberOfIslands.CountIslands(Grid("10", "1")));
        Assert.Throws<ArgumentException>(
            () => Day007NumberOfIslands.CountIslands(Grid("", "0")));
    }

    [Fact]
    public void InvalidCharacters_ThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Day007NumberOfIslands.CountIslands(Grid("1x")));
        Assert.Throws<ArgumentException>(() => Day007NumberOfIslands.CountIslands(Grid("2")));
        Assert.Throws<ArgumentException>(() => Day007NumberOfIslands.CountIslands(Grid(" ")));
    }

    [Fact]
    public void InputIsUnchanged_AndMultipleCallsReturnSameAnswer()
    {
        var grid = Grid("110", "010", "001", "110");
        var original = grid.Select(row => new string(row)).ToArray();
        var originalRows = grid.ToArray();

        Assert.Equal(3, Day007NumberOfIslands.CountIslands(grid));
        Assert.Equal(3, Day007NumberOfIslands.CountIslands(grid));
        for (var row = 0; row < grid.Length; row++)
        {
            Assert.Same(originalRows[row], grid[row]);
            Assert.Equal(original[row], new string(grid[row]));
        }
    }

    [Fact]
    public void VeryLongConnectedRow_DoesNotRequireDeepRecursion()
    {
        Assert.Equal(1, Day007NumberOfIslands.CountIslands(Grid(new string('1', 120_000))));
    }

    [Fact]
    public void LargeCheckerboard_HasFortyFiveThousandIslands()
    {
        var grid = new char[300][];
        for (var row = 0; row < 300; row++)
        {
            grid[row] = new char[300];
            for (var column = 0; column < 300; column++)
                grid[row][column] = (row + column) % 2 == 0 ? '1' : '0';
        }
        Assert.Equal(45_000, Day007NumberOfIslands.CountIslands(grid));
    }

    [Fact]
    public void FourHundredRandomGrids_MatchIndependentUnionFind()
    {
        var random = new Random(20261014);
        for (var caseIndex = 0; caseIndex < 400; caseIndex++)
        {
            var rows = random.Next(0, 10);
            var columns = random.Next(0, 11);
            var grid = new char[rows][];
            for (var row = 0; row < rows; row++)
            {
                grid[row] = new char[columns];
                for (var col = 0; col < columns; col++)
                    grid[row][col] = random.Next(2) == 0 ? '0' : '1';
            }
            Assert.Equal(UnionFindCount(grid), Day007NumberOfIslands.CountIslands(grid));
        }
    }

    private static int UnionFindCount(char[][] grid)
    {
        if (grid.Length == 0 || grid[0].Length == 0) return 0;
        var rows = grid.Length;
        var cols = grid[0].Length;
        var parents = Enumerable.Range(0, rows * cols).ToArray();
        var count = 0;

        int Root(int index)
        {
            while (parents[index] != index)
            {
                parents[index] = parents[parents[index]];
                index = parents[index];
            }
            return index;
        }

        void Join(int first, int second)
        {
            first = Root(first);
            second = Root(second);
            if (first == second) return;
            parents[second] = first;
            count--;
        }

        for (var row = 0; row < rows; row++)
            for (var col = 0; col < cols; col++)
                if (grid[row][col] == '1')
                    count++;

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (grid[row][col] != '1') continue;
                var id = row * cols + col;
                if (row + 1 < rows && grid[row + 1][col] == '1')
                    Join(id, id + cols);
                if (col + 1 < cols && grid[row][col + 1] == '1')
                    Join(id, id + 1);
            }
        }
        return count;
    }
}
