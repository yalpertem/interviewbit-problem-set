using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.BinarySearch
{
    /// <summary>
    /// Square Root of Integer
    /// https://www.interviewbit.com/problems/square-root-of-integer/
    /// </summary>
    public class SquareRootOfInteger
    {
        /*
            Given an integar A.
            Compute and return the square root of A.
            If A is not a perfect square, return floor(sqrt(A)).
            DO NOT USE SQRT FUNCTION FROM STANDARD LIBRARY

            Input Format
            The first and only argument given is the integer A.

            Output Format
            Return floor(sqrt(A))

            Constraints
            1 <= A <= 10^9
            For Example

            Input 1:
            A = 11
            Output 1:
            3

            Input 2:
            A = 9
            Output 2:
            3
        */

        public int Solve(int num)
        {
            if (num == 0 || num == 1)
            {
                return num;
            }

            var start = 0;
            var end = num - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                long candidate = (long)mid * mid;

                if (candidate == num)
                {
                    return mid;
                }
                if (candidate > num)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            if ((long)end * end < num)
            {
                while ((long)end * end < num)
                {
                    end++;
                }
                return end - 1;
            }
            else
            {
                while ((long)end * end > num)
                {
                    end--;
                }
                return end;
            }
        }
    }
}
