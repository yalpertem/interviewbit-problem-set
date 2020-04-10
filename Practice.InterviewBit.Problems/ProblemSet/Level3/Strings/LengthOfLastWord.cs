using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.Strings
{
    /// <summary>
    /// Length of Last Word
    /// https://www.interviewbit.com/problems/length-of-last-word/
    /// </summary>
    public class LengthOfLastWord
    {
        /*
        Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
        If the last word does not exist, return 0.
        Note: A word is defined as a character sequence consists of non-space characters only.
        
        Example:
        Given s = "Hello World",
        return 5 as length("World") = 5.

        Please make sure you try to solve this problem without using library functions. Make sure you only traverse the string once.
        */

        public int Solve(string A)
        {
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            int length = 0;
            var endIndex = -1;

            for (var i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] == ' ')
                {
                    if (endIndex == -1)
                    {
                        continue;
                    }
                    else
                    {
                        return length;
                    }
                }
                else
                {
                    if (endIndex == -1)
                    {
                        endIndex = i;
                    }
                    length++;
                }
            }
            return length;
        }
    }
}
