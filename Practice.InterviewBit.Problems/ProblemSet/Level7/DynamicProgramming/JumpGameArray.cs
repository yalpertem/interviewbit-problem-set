using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Jump Game Array
    /// https://www.interviewbit.com/problems/jump-game-array/
    /// </summary>
    public class JumpGameArray
    {
        /*
        Given an array of non-negative integers, A, you are initially positioned at the first index of the array.
        Each element in the array represents your maximum jump length at that position.
        Determine if you are able to reach the last index.

        Input Format:
        The first and the only argument of input will be an integer array A.
        Output Format:
        Return an integer, representing the answer as described in the problem statement.
            => 0 : If you cannot reach the last index.
            => 1 : If you can reach the last index.
        Constraints:
        1 <= len(A) <= 1e6
        0 <= A[i] <= 30

        Examples:

        Input 1:
            A = [2,3,1,1,4]
        Output 1:
            1

        Explanation 1:
            Index 0 -> Index 2 -> Index 3 -> Index 4 -> Index 5
        Input 2:
            A = [3,2,1,0,4]
        Output 2:
            0
        Explanation 2:
            There is no possible path to reach the last index.
        */

        public int Solve(List<int> nums)
        {
            if (nums == null || nums.Count <= 2)
            {
                return 1;
            }

            var prev = nums.Count - 2;
            var needed = 1;
            while (prev >= 0)
            {
                if (nums[prev] >= needed)
                {
                    if (prev == 0)
                    {
                        return 1;
                    }
                    prev--;
                    needed = 1;
                }
                else
                {
                    prev--;
                    needed++;
                }
            }
            return 0;
        }
    }
}
