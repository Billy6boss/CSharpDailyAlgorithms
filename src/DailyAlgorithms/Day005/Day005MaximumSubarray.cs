namespace DailyAlgorithms.Day005;

/// <summary>
/// Day 005: Maximum Subarray / 最大連續子陣列和。
/// </summary>
public static class Day005MaximumSubarray
{
    /// <summary>
    /// 回傳最大連續子陣列和。非空輸入必須選取至少一個元素。
    /// 空陣列回傳 0；null 擲出 ArgumentNullException。
    /// 不得修改輸入；使用 long 表達總和，避免 int 溢位。
    /// 挑戰：O(n) 時間、O(1) 額外空間。
    /// </summary>
    /// <example>
    /// Day005MaximumSubarray.Solve([5, -10, 6]); // 6，區間 [6]
    /// Day005MaximumSubarray.Solve([-2, 1, -3, 4, -1, 2, 1, -5, 4]); // 6，區間 [4, -1, 2, 1]
    /// Day005MaximumSubarray.Solve([2, 1, -3, 4, -1, 2, 1, -5, 4]); // 6，區間 [4, -1, 2, 1]
    /// Day005MaximumSubarray.Solve([5, 4, -1, 7, 8]);                // 23
    /// Day005MaximumSubarray.Solve([-5, -2, -9]);                   // -2
    /// Day005MaximumSubarray.Solve([]);                            // 0
    /// Day005MaximumSubarray.Solve([int.MaxValue, int.MaxValue]);   // 4294967294L
    /// </example>
    public static long Solve(int[] numbers)
    {
        ArgumentNullException.ThrowIfNull(numbers);
        if (numbers.Length <= 0)
        {
            return 0;
        }

        long sum = numbers[0];
        long currentBest = numbers[0];

        for (var i = 1; i < numbers.Length; i++)
        {
            sum += numbers[i];
            
            // is add this number help?
            if (sum  > currentBest)
            {
                // yes then it can be the best
                currentBest = sum;
            }
            
            // however if the number itself is bigger then the sum, mean the previs number are not helping
            if (numbers[i] > currentBest)
            {
                currentBest = numbers[i];
            }

            // number itself is bigger than the sum so far. need to restart to track to get future number that can help bigger.
            if (numbers[i] > sum)
            {
                sum = numbers[i];
            }
        }

        return currentBest;
    }
    
    
//     if (number > max)
//     {
//         max = number;
//     }
// if (number < min)
// {
//     min = number;
// }
}
