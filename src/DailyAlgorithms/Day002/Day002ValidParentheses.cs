namespace DailyAlgorithms;

/// <summary>
/// Day 002: Valid Parentheses / 有效括號。
/// </summary>
public static class Day002ValidParentheses
{
    private static readonly HashSet<char> beginner =
    [
        '(', '[', '{'
    ];

    /// <summary>
    /// 檢查輸入字串的括號是否成對且正確巢狀。
    /// 空字串是有效的；除 ()[]{} 以外的任何字元視為無效，回傳 false。
    /// brackets 為 null 時擲出 ArgumentNullException。
    /// </summary>
    /// <exception cref="ArgumentNullException">when brackets is null</exception>
    public static bool IsValid(string brackets)
    {
        ArgumentNullException.ThrowIfNull(brackets);

        var tracking = new Stack<char>();
            
        foreach (var currentChar in brackets)
        {
            if (beginner.Contains(currentChar))
            {
                tracking.Push(currentChar);
            }
            else
            {
                if (!tracking.TryPop(out var previsChar))
                {
                    return false;
                }

                switch (currentChar)
                {
                    case ')':
                        if (previsChar == '(')
                        {
                            continue;
                        }

                        return false;
                    case ']':
                        if (previsChar == '[')
                        {
                            continue;
                        }

                        return false;
                    case '}':
                        if (previsChar == '{')
                        {
                            continue;
                        }

                        return false;
                    default:
                        return false;
                }
            }
        }

        return tracking.Count == 0;
    }
}
