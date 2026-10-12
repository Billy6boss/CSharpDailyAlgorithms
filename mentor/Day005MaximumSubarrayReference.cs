// 參考答案：此檔刻意不納入任何 .csproj 編譯。
// 建議先完成 src/DailyAlgorithms/Day005MaximumSubarray.cs。
using System;

namespace DailyAlgorithms.Mentor;

public static class Day005MaximumSubarrayReference
{
    public static long Solve(int[] numbers)
    {
        ArgumentNullException.ThrowIfNull(numbers);
        if (numbers.Length == 0)
        {
            return 0;
        }

        long endingHere = numbers[0];
        long best = endingHere;

        for (var index = 1; index < numbers.Length; index++)
        {
            // 最佳區間若以目前元素結尾，只有「重新開始」或「延伸前一段」。
            endingHere = Math.Max((long)numbers[index], endingHere + numbers[index]);
            best = Math.Max(best, endingHere);
        }

        return best;
    }
}
