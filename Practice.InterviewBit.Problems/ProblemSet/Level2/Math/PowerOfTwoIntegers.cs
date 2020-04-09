using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Math
{
    /// <summary>
    /// Power Of Two Integers
    /// https://www.interviewbit.com/problems/power-of-two-integers/
    /// </summary>
    public class PowerOfTwoIntegers
    {
        /*
        Given a positive integer which fits in a 32 bit signed integer, find if it can be expressed as A^P where P > 1 and A > 0. A and P both should be integers.

        Example
        Input : 4
        Output : True  
        as 2^2 = 4.
        */

        public int Solve(int num)
        {
            if (num == 1)
            {
                return 1;
            }

            for (var i = System.Math.Sqrt(num); i >= 2; i--)
            {
                var baseNumber = i;
                while (baseNumber < num)
                {
                    baseNumber *= i;
                    if (baseNumber == num)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
    }
}
