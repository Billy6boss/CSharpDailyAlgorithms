// Day 006 reference only (mentor/ is excluded from the Solution).
using System;
using System.Collections.Generic;

namespace DailyAlgorithms.Mentor;

public static class Day006MergeIntervalsReference
{
    public static int[][] Merge(int[][] intervals)
    {
        ArgumentNullException.ThrowIfNull(intervals);

        var sorted = new (int Start, int End)[intervals.Length];
        for (var i = 0; i < intervals.Length; i++)
        {
            var row = intervals[i];
            if (row is null || row.Length != 2 || row[0] > row[1])
            {
                throw new ArgumentException(
                    "Each interval must have start <= end and exactly two integers.",
                    nameof(intervals));
            }

            sorted[i] = (row[0], row[1]);
        }

        if (sorted.Length == 0)
            return Array.Empty<int[]>();

        Array.Sort(sorted, static (a, b) =>
        {
            var result = a.Start.CompareTo(b.Start);
            return result != 0 ? result : a.End.CompareTo(b.End);
        });

        var merged = new List<int[]>(sorted.Length);
        var start = sorted[0].Start;
        var end = sorted[0].End;

        for (var i = 1; i < sorted.Length; i++)
        {
            var next = sorted[i];
            if (next.Start <= end)
            {
                end = Math.Max(end, next.End);
            }
            else
            {
                merged.Add(new[] { start, end });
                start = next.Start;
                end = next.End;
            }
        }

        merged.Add(new[] { start, end });
        return merged.ToArray();
    }
}
