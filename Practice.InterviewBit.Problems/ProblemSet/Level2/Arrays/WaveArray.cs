using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays
{
    /// <summary>
    /// Wave Array
    /// https://www.interviewbit.com/problems/wave-array/
    /// </summary>
    public class WaveArray
    {
        /*
        Given an array of integers, sort the array into a wave like array and return it,
        In other words, arrange the elements into a sequence such that a1 >= a2 <= a3 >= a4 <= a5.....

        Example
        Given [1, 2, 3, 4]
        One possible answer : [2, 1, 4, 3]
        Another possible answer : [4, 1, 3, 2]

        NOTE : If there are multiple answers possible, return the one thats lexicographically smallest.
        So, in example case, you will return [2, 1, 4, 3]
        */

        public List<int> Solve(List<int> list)
        {
            list.Sort();
            for (var i = 0; i < list.Count - 1; i += 2)
            {
                var temp = list[i + 1];
                list[i + 1] = list[i];
                list[i] = temp;
            }
            return list;
        }
    }
}
