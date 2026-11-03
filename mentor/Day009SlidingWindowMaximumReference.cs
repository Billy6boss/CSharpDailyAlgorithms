// Mentor-only reference. This file is outside src/ and tests/, and is not compiled.
using System;
using System.Collections.Generic;

namespace DailyAlgorithms.Mentor;

public static class Day009SlidingWindowMaximumReference
{
    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        ArgumentNullException.ThrowIfNull(nums);
        if (k <= 0 || k > nums.Length)
            throw new ArgumentOutOfRangeException(nameof(k));

        var answer = new int[nums.Length - k + 1];
        var deque = new LinkedList<int>(); // Indexes from oldest to newest.

        for (var i = 0; i < nums.Length; i++)
        {
            // Current window starts at i - k + 1. Old indexes are expired.
            if (deque.First is not null && deque.First.Value <= i - k)
                deque.RemoveFirst();

            // Smaller/equal old values can never beat the new value in a future window.
            while (deque.Last is not null && nums[deque.Last.Value] <= nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            if (i >= k - 1)
                answer[i - k + 1] = nums[deque.First!.Value];
        }

        return answer;
    }
}
