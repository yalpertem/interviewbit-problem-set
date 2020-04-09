using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.BitManipulation
{
    /// <summary>
    /// Single Number
    /// https://www.interviewbit.com/problems/single-number/
    /// </summary>
    public class SingleNumber
    {
        /*
        Given an array of integers, every element appears twice except for one. Find that single one.
        Note: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

        Input Format:
            First and only argument of input contains an integer array A
        Output Format:
            return a single integer denoting single element
        
        Constraints:
        2 <= N <= 2 000 000  
        0 <= A[i] <= INT_MAX

        Examples :

        Example Input 1:
            A = [1, 2, 2, 3, 1]
        Example Output 1:
            3
        Explanation:
            3 occurs only once

        Example Input 2:
            A = [1, 2, 2]
        Example Output 2:
            1
        */

        public int Solve(List<int> nums)
        {
            var result = 0;
            for (var i = 0; i < nums.Count; i++)
            {
                result ^= nums[i];
            }
            return result;
        }
    }
}
