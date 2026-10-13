// 參考答案：此檔刻意不納入 .csproj 編譯。
// 請先完成 src/DailyAlgorithms/Day002ValidParentheses.cs，再閱讀比較。
using System;
using System.Collections.Generic;

namespace DailyAlgorithms.Mentor;

public static class Day002ValidParenthesesReference
{
    public static bool IsValid(string brackets)
    {
        ArgumentNullException.ThrowIfNull(brackets);

        if ((brackets.Length & 1) != 0)
        {
            return false;
        }

        var opens = new Stack<char>();

        foreach (var symbol in brackets)
        {
            switch (symbol)
            {
                case '(':
                case '[':
                case '{':
                    opens.Push(symbol);
                    break;
                case ')':
                    if (opens.Count == 0 || opens.Pop() != '(')
                        return false;
                    break;
                case ']':
                    if (opens.Count == 0 || opens.Pop() != '[')
                        return false;
                    break;
                case '}':
                    if (opens.Count == 0 || opens.Pop() != '{')
                        return false;
                    break;
                default:
                    return false;
            }
        }

        return opens.Count == 0;
    }
}
