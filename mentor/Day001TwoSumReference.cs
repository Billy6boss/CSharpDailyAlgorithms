// 參考答案：此檔刻意不納入任何 .csproj 編譯。
// 建議自己先完成 src/DailyAlgorithms/Day001TwoSum.cs，再看此檔。
using System;
using System.Collections.Generic;

namespace DailyAlgorithms.Mentor;

public static class Day001TwoSumReference
{
    public static int[] Solve(int[] numbers, int target)
    {
        ArgumentNullException.ThrowIfNull(numbers);

        var firstIndexByValue = new Dictionary<int, int>(numbers.Length);

        for (var currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
        {
            // 使用 long，避免 target - numbers[currentIndex] 發生 Int32 overflow。
            var complement = (long)target - numbers[currentIndex];
            if (complement >= int.MinValue && complement <= int.MaxValue &&
                firstIndexByValue.TryGetValue((int)complement, out var earlierIndex))
            {
                return new[] { earlierIndex, currentIndex };
            }

            firstIndexByValue.TryAdd(numbers[currentIndex], currentIndex);
        }

        return Array.Empty<int>();
    }
}
