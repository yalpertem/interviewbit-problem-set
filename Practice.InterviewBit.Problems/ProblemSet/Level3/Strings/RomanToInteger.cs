using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.Strings
{
    /// <summary>
    /// Roman To Integer
    /// https://www.interviewbit.com/problems/roman-to-integer/
    /// </summary>
    public class RomanToInteger
    {
        /*
        Given a string A representing a roman numeral.
        Convert A into integer.

        A is guaranteed to be within the range from 1 to 3999.
        NOTE: Read more details about roman numerals at Roman Numeric System:
        https://en.wikipedia.org/wiki/Roman_numerals#Roman_numeric_system

        */

        public int Solve(string A)
        {
            if (A == null || A == "")
            {
                return 0;
            }

            int num = 0;
            for (var i = 1; i < A.Length; i++)
            {
                var prev = GetValue(A[i - 1]);
                var next = GetValue(A[i]);
                if (prev >= next)
                {
                    num += prev;
                }
                else
                {
                    num -= prev;
                }
            }
            num += GetValue(A[^1]);
            return num;
        }

        private int GetValue(char c)
        {
            return c switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0,
            };
        }
    }
}
