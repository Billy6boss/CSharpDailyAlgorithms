// 參考答案：不編入任何 .csproj；請先完成題目。
using System;

namespace DailyAlgorithms.Mentor;

public static class Day003BinarySearchReference
{
    public static int FindFirstIndex(int[] numbers, int target)
    {
        ArgumentNullException.ThrowIfNull(numbers);
        var left = 0;
        var right = numbers.Length;

        // 搜尋區間 [left, right)，找出第一個 >= target 的位置。
        while (left < right)
        {
            var middle = left + (right - left) / 2;
            if (numbers[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle;
            }
        }

        return left < numbers.Length && numbers[left] == target ? left : -1;
    }
}
