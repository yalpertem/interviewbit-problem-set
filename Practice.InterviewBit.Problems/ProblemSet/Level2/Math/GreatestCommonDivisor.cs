using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Math
{
    /// <summary>
    /// Greatest Common Divisor
    /// https://www.interviewbit.com/problems/greatest-common-divisor/
    /// </summary>
    public class GreatestCommonDivisor
    {
        /*
        Given 2 non negative integers m and n, find gcd(m, n)
        GCD of 2 integers m and n is defined as the greatest integer g such that g is a divisor of both m and n.
        Both m and n fit in a 32 bit signed integer.

        Example
        m : 6
        n : 9
        GCD(m, n) : 3 

        NOTE : DO NOT USE LIBRARY FUNCTIONS 
        */

        public int Solve(int num1, int num2)
        {
            if (num1 == 0 && num2 == 0)
            {
                return 0;
            }
            if (num1 == 0)
            {
                return num2;
            }
            if (num2 == 0)
            {
                return num1;
            }

            var smallerNumber = num1 > num2 ? num2 : num1;
            for (var i = smallerNumber; i > 1; i--)
            {
                if (num1 % i == 0 && num2 % i == 0)
                {
                    return i;
                }
            }
            return 1;
        }
    }
}
