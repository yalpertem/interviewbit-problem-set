using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Math
{
    /// <summary>
    /// Palindrome Integer
    /// https://www.interviewbit.com/problems/palindrome-integer/
    /// </summary>
    public class PalindromeInteger
    {
        /*
        Determine whether an integer is a palindrome. Do this without extra space.
        A palindrome integer is an integer x for which reverse(x) = x where reverse(x) is x with its digit reversed.
        Negative numbers are not palindromic.

        Example :
        
        Input : 12121
        Output : True

        Input : 123
        Output : False

        -- Return 1 for true, 0 for false
        */

        public int Solve(int num)
        {
            if (num < 0)
            {
                return 0;
            }

            if (num < 10)
            {
                return 1;
            }

            int digitCount = 0;
            int toBeDivided = num;
            while (toBeDivided > 0)
            {
                toBeDivided /= 10;
                digitCount++;
            }

            toBeDivided = num;
            var reverse = 0;
            for (var i = digitCount; i > 0; i--)
            {
                reverse += (toBeDivided % 10) * (int)System.Math.Pow(10, i);
                toBeDivided /= 10;
            }

            return reverse == num ? 1 : 0;
        }
    }
}
