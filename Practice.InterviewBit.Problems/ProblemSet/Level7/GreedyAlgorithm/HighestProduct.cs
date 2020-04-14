using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.GreedyAlgorithm
{
    /// <summary>
    /// Highest Product
    /// https://www.interviewbit.com/problems/highest-product/
    /// </summary>
    public class HighestProduct
    {
        /*
        Given an array A, of N integers A.
        Return the highest product possible by multiplying 3 numbers from the array.
        NOTE: Solution will fit in a 32-bit signed integer.

        Input Format:
        The first and the only argument is an integer array A.
        Output Format:
        Return the highest possible product.
        Constraints:
        1 <= N <= 5e5

        Example:
        Input 1:
        A = [1, 2, 3, 4]
        Output 1:
        24
        Explanation 1:
        2 * 3 * 4 = 24

        Input 2:
        A = [0, -1, 3, 100, 70, 50]
        Output 2:
        350000
        Explanation 2:
        70 * 50 * 100 = 350000

        */

        public int Solve(List<int> nums)
        {
            if (nums == null || nums.Count < 3)
            {
                return 0;
            }

            var first = int.MinValue;
            var second = int.MinValue;
            var third = int.MinValue;

            var negativeFirst = 1;
            var negativeSecond = 1;

            for (var i = 0; i < nums.Count; i++)
            {
                if (nums[i] >= first)
                {
                    third = second;
                    second = first;
                    first = nums[i];
                }
                else if (nums[i] >= second)
                {
                    third = second;
                    second = nums[i];
                }
                else if (nums[i] >= third)
                {
                    third = nums[i];
                }

                if (nums[i] < 0)
                {
                    if (nums[i] <= negativeFirst)
                    {
                        negativeSecond = negativeFirst;
                        negativeFirst = nums[i];
                    }
                    else if (nums[i] <= negativeSecond)
                    {
                        negativeSecond = nums[i];
                    }
                }
            }

            var result = first * second * third;
            if (negativeFirst != 1 && negativeSecond != 1)
            {
                result = Math.Max(result, first * negativeFirst * negativeSecond);
            }
            return result;
        }
    }
}
