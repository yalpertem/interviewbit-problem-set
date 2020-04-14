using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Unique Binary Search Trees II
    /// https://www.interviewbit.com/problems/unique-binary-search-trees-ii/
    /// </summary>
    public class UniqueBinarySearchTreesII
    {
        /*
        Given an integer A, how many structurally unique BST’s (binary search trees) exist that can store values 1…A?

        Input Format:
        The first and the only argument of input contains the integer, A.
        
        Output Format:
        Return an integer, representing the answer asked in problem statement.
        
        Constraints:
        1 <= A <= 18
        
        Example:
        Input 1:
            A = 3
        Output 1:
            5
        Explanation 1:
           1         3     3      2      1
            \       /     /      / \      \
             3     2     1      1   3      2
            /     /       \                 \
           2     1         2                 3

        */

        public int Solve(int A)
        {
            var dp = CreateDP(A);
            var result = GetNumTreesDP(A, dp);
            return result;
        }

        private int[] CreateDP(int A)
        {
            var dp = new int[A + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (var i = 2; i <= A; i++)
            {
                dp[i] = -1;
            }
            return dp;
        }

        private int GetNumTreesDP(int A, int[] dp)
        {
            if (dp[A] != -1)
            {
                return dp[A];
            }

            var total = 0;
            for (var i = 0; i < A; i++)
            {
                var left = GetNumTreesDP(A - i - 1, dp);
                var right = GetNumTreesDP(i, dp);
                total += left * right;
            }
            dp[A] = total;
            return total;
        }
    }
}
