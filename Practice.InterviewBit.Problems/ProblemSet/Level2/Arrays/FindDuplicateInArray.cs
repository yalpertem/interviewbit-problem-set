using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays
{
    /// <summary>
    /// Find Duplicate in Array
    /// https://www.interviewbit.com/problems/find-duplicate-in-array/
    /// </summary>
    public class FindDuplicateInArray
    {
        /*
        Given a read only array of n + 1 integers between 1 and n, find one number that repeats in linear time using less than O(n) space and traversing the stream sequentially O(1) times.

        Sample Input:
        [3 4 1 4 1]
        Sample Output:
        1
        
        If there are multiple possible answers ( like in the sample case above ), output any one.
        If there is no duplicate, output -1
        */

        public int Solve(List<int> list)
        {
            if (list == null || list.Count < 2)
            {
                return -1;
            }

            var slow = list[0];
            var fast = list[list[0]];

            while (slow != fast)
            {
                slow = list[slow];
                fast = list[list[fast]];
            }

            slow = 0;
            while (slow != fast)
            {
                slow = list[slow];
                fast = list[fast];
            }

            return slow;
        }
    }
}
