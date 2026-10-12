namespace DailyAlgorithms;

/// <summary>
/// Day 001: Two Sum / 兩數之和。
/// </summary>
public static class Day001TwoSum
{
    /// <summary>
    /// 回傳任一組相異索引，滿足 numbers[i] + numbers[j] == target，
    /// 且 i > j。找不到時回傳空陣列。numbers 為 null 時擲出 ArgumentNullException。
    /// 請勿修改輸入陣列。
    /// </summary>
    public static int[] Solve(int[] numbers, int target)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers));
        }

        var memery = new Dictionary<long, int>();
        long longTarget = target;
        
        for (int i = 0; i < numbers.Length; i++)
        {
            long nowNumber = numbers[i];
            
            if (memery.TryGetValue(longTarget - nowNumber, out var j))
            {
                return [j, i];
            }

            memery.TryAdd(nowNumber, i);
        }
        
        return [];
    }
}
