using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays
{
    /// <summary>
    /// Max Non Negative SubArray
    /// https://www.interviewbit.com/problems/max-non-negative-subarray/
    /// </summary>
    public class MaxNonNegativeSubArray
    {
        /*
        Given an array of integers, A of length N, find out the maximum sum sub-array of non negative numbers from A.
        The sub-array should be contiguous i.e., a sub-array created by choosing the second and fourth element and skipping the third element is invalid.
        Maximum sub-array is defined in terms of the sum of the elements in the sub-array.
        Find and return the required subarray.

        NOTE:
            1. If there is a tie, then compare with segment's length and return segment which has maximum length.
            2. If there is still a tie, then return the segment with minimum starting index.

        Input Format:
        The first and the only argument of input contains an integer array A, of length N.

        Output Format:
        Return an array of integers, that is a subarray of A that satisfies the given conditions.

        Constraints:

        1 <= N <= 1e5
        1 <= A[i] <= 1e5

        Examples:

        Input 1:
            A = [1, 2, 5, -7, 2, 3]
        Output 1:
            [1, 2, 5]
        Explanation 1:
            The two sub-arrays are [1, 2, 5] [2, 3].
            The answer is [1, 2, 5] as its sum is larger than [2, 3].

        Input 2:
            A = [10, -1, 2, 3, -4, 100]
        Output 2:
            [100]
        Explanation 2:
            The three sub-arrays are [10], [2, 3], [100].
            The answer is [100] as its sum is larger than the other two.
        */

        public List<int> Solve(List<int> list)
        {
            int maxStart = 0, maxEnd = 0;
            int curStart = 0, curEnd = 0;
            long maxSum = 0, curSum = 0;
            bool hasAnyNonNegative = false;

            while (curEnd < list.Count)
            {
                if (list[curEnd] < 0)
                {
                    curEnd++;
                    curStart = curEnd;
                    curSum = 0;
                }
                else
                {
                    hasAnyNonNegative = true;
                    curSum += list[curEnd];
                    curEnd++;
                    if ((curSum > maxSum) ||
                        (curSum == maxSum) && (curEnd - curStart) > (maxEnd - maxStart))
                    {
                        maxStart = curStart;
                        maxEnd = curEnd - 1;
                        maxSum = curSum;
                    }
                }
            }

            var maxSubArray = new List<int>();
            if (!hasAnyNonNegative)
            {
                return maxSubArray;
            }

            for (var i = maxStart; i <= maxEnd; i++)
            {
                maxSubArray.Add(list[i]);
            }
            return maxSubArray;
        }
    }
}
