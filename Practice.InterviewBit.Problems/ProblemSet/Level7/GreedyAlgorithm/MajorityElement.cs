using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.GreedyAlgorithm
{
    /// <summary>
    /// Majority Element
    /// https://www.interviewbit.com/problems/majority-element/
    /// </summary>
    public class MajorityElement
    {
        /*
        Given an array of size n, find the majority element. The majority element is the element that appears more than floor(n/2) times.

        You may assume that the array is non-empty and the majority element always exist in the array.

        Example :

        Input : [2, 1, 2]
        Return  : 2 which occurs 2 times which is greater than 3/2. 
        */

        /// <summary>
        /// O(n) time, O(n) space.
        /// See Solve2 for O(1) space.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Solve(List<int> nums)
        {
            int majorityNum = 0;
            var majorityCount = 0;
            var minLimit = nums.Count / 2;
            var occurences = new Dictionary<int, int>();
            for (var i = 0; i < nums.Count; i++)
            {
                var num = nums[i];
                if (occurences.ContainsKey(num))
                {
                    occurences[num] += 1;
                }
                else
                {
                    occurences.Add(num, 1);
                }
                if (occurences[num] > majorityCount)
                {
                    majorityCount = occurences[num];
                    majorityNum = num;
                }

                if (majorityCount > minLimit)
                {
                    break;
                }
            }
            return majorityNum;
        }

        /// <summary>
        /// Editorial Solution: O(n) time, O(1) space.
        /// See Solve for O(n) space.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SolveEditorial(List<int> nums)
        {
            var count = 1;
            var maj = 0;
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[maj] == nums[i]) count++;
                else
                {
                    count--;
                    if (count == 0)
                    {
                        count = 1;
                        maj = i;
                    }

                }
            }
            return nums[maj];
        }
    }
}
