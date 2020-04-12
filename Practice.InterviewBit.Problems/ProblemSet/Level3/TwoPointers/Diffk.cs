using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.TwoPointers
{
    /// <summary>
    /// Diffk
    /// https://www.interviewbit.com/problems/diffk/
    /// </summary>
    public class Diffk
    {
        /*
        Given an array ‘A’ of sorted integers and another non negative integer k, find if there exists 2 indices i and j such that A[i] - A[j] = k, i != j.

        Example:
        Input : 
        A : [1 3 5] 
        k : 4
        Output : YES as 5 - 1 = 4 
        Return 0 / 1 ( 0 for false, 1 for true ) for this problem

        Try doing this in less than linear space complexity.
        */

        public int Solve(List<int> nums, int k)
        {
            if (nums == null || nums.Count < 2)
            {
                return 0;
            }
            int i = 0, j = 1;
            k = Math.Abs(k);
            while (i < nums.Count)
            {
                var diff = nums[j] - nums[i];
                if (diff == k)
                {
                    return 1;
                }
                else if (diff < k)
                {
                    j++;
                }
                else
                {
                    i++;
                }

                if (i == j)
                {
                    j++;
                }

                if (j >= nums.Count)
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
