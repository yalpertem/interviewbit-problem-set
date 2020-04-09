using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays
{
    /// <summary>
    /// Next Permutation
    /// https://www.interviewbit.com/problems/next-permutation/
    /// </summary>
    public class NextPermutation
    {
        /*
        Implement the next permutation, which rearranges numbers into the numerically next greater permutation of numbers for a given array A of size N.
        If such arrangement is not possible, it must be rearranged as the lowest possible order i.e., sorted in an ascending order.

        Note:
        1. The replacement must be in-place, do **not** allocate extra memory.
        2. DO NOT USE LIBRARY FUNCTION FOR NEXT PERMUTATION. Use of Library functions will disqualify your submission retroactively and will give you penalty points.
        
        Input Format:
        The first and the only argument of input has an array of integers, A.
        Output Format:
        Return an array of integers, representing the next permutation of the given array.

        Constraints:
        1 <= N <= 5e5
        1 <= A[i] <= 1e9

        Examples:

        Input 1:
            A = [1, 2, 3]
        Output 1:
            [1, 3, 2]

        Input 2:
            A = [3, 2, 1]
        Output 2:
            [1, 2, 3]

        Input 3:
            A = [1, 1, 5]
        Output 3:
            [1, 5, 1]

        Input 4:
            A = [20, 50, 113]
        Output 4:
            [20, 113, 50]
        */

        public List<int> Solve(List<int> list)
        {
            for (var i = list.Count - 1; i > 1; i--)
            {
                if (list[i - 1] < list[i])
                {
                    SwapWithTheSmallestLargerNumber(list, i - 1);
                    ReverseRestOfTheList(list, i);
                    return list;
                }
            }

            // could not find next permutation
            // return in ascending order
            list.Reverse();
            return list;
        }

        private void SwapWithTheSmallestLargerNumber(List<int> A, int index)
        {
            var current = A[index];
            for (int i = A.Count - 1; i > index; i--)
            {
                if (current < A[i])
                {
                    //Console.WriteLine("swap " + A[index] + " with " + A[i]);
                    Swap(A, index, i);
                    break;
                }
            }
        }

        private void ReverseRestOfTheList(List<int> A, int start)
        {
            int end = A.Count - 1;
            while (start < end)
            {
                Swap(A, start, end);
                start++;
                end--;
            }
        }

        private void Swap(List<int> A, int i, int j)
        {
            var temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }
}
