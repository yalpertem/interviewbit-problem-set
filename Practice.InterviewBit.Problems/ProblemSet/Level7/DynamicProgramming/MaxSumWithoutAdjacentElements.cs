using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Max Sum Without Adjacent Elements
    /// https://www.interviewbit.com/problems/max-sum-without-adjacent-elements/
    /// </summary>
    public class MaxSumWithoutAdjacentElements
    {
        /*
        Given a 2 x N grid of integer, A, choose numbers such that the sum of the numbers
        is maximum and no two chosen numbers are adjacent horizontally, vertically or diagonally, and return it.
        Note: You can choose more than 2 numbers.

        Input Format:
        The first and the only argument of input contains a 2d matrix, A.
        Output Format:
        Return an integer, representing the maximum possible sum.
        Constraints:
        1 <= N <= 20000
        1 <= A[i] <= 2000

        Example:

        Input 1:
            A = [   [1]
                    [2]    ]
        Output 1:
            2
        Explanation 1:
            We will choose 2.
        
        Input 2:
            A = [   [1, 2, 3, 4]
                    [2, 3, 4, 5]    ]
        Output 2:
            We will choose 3 and 5.
        */

        public int Solve(List<List<int>> A)
        {
            if (A == null || A.Count == 0 || A[0].Count == 0)
            {
                return 0;
            }

            var flattened = FlattenList(A);
            var dp = new int[flattened.Count];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = -1;
            }
            var result = CalculateMaxValues(flattened, 0, dp);
            return result;
        }

        private int CalculateMaxValues(List<int> flattened, int start, int[] dp)
        {
            if (start >= dp.Length)
            {
                return 0;
            }

            if (dp[start] != -1)
            {
                return dp[start];
            }

            var candidate1 = flattened[start] + CalculateMaxValues(flattened, start + 2, dp);
            var candidate2 = CalculateMaxValues(flattened, start + 1, dp);
            var max = Math.Max(candidate1, candidate2);
            dp[start] = max;
            return max;
        }

        private List<int> FlattenList(List<List<int>> A)
        {
            var flattened = new List<int>();
            for (var i = 0; i < A[0].Count; i++)
            {
                var num = Math.Max(A[0][i], A[1][i]);
                flattened.Add(num);
            }
            return flattened;
        }

    }
}
