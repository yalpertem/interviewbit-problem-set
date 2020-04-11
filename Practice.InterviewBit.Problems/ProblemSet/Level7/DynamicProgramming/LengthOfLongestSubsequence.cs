using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Length of Longest Subsequence
    /// https://www.interviewbit.com/problems/length-of-longest-subsequence/
    /// </summary>
    public class LengthOfLongestSubsequence
    {
        /*
        Given an array of integers, A of length N, find the length of longest subsequence which is first increasing then decreasing.

        Input Format:
        The first and the only argument contains an integer array, A.
        
        Output Format:
        Return an integer representing the answer as described in the problem statement.
        
        Constraints:
        1 <= N <= 3000
        1 <= A[i] <= 1e7
        
        Example:

        Input 1:
            A = [1, 2, 1]
        Output 1:
            3
        Explanation 1:
            [1, 2, 1] is the longest subsequence.

        Input 2:
            [1, 11, 2, 10, 4, 5, 2, 1]
        Output 2:
            6
        Explanation 2:
            [1 2 10 4 2 1] is the longest subsequence.
        */

        public int Solve(List<int> list)
        {
            if (list == null || list.Count == 0)
            {
                return 0;
            }

            var dpI = GetIncreasingLengths(list);
            list.Reverse();
            var dpD = GetIncreasingLengths(list);
            Array.Reverse(dpD);

            var maxLength = 1;
            for (var i = 0; i < dpI.Length; i++)
            {
                maxLength = Math.Max(maxLength, dpI[i] + dpD[i] - 1);
            }
            return maxLength;
        }

        private int[] GetIncreasingLengths(List<int> list)
        {
            var dp = new int[list.Count];
            dp[0] = 1;
            for (var i = 1; i < list.Count; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (list[i] > list[j] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                    }
                }
            }
            return dp;
        }
    }
}
