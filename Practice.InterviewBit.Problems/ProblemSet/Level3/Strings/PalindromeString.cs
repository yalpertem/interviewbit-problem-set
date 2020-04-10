using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.Strings
{
    /// <summary>
    /// Palindrome String
    /// https://www.interviewbit.com/problems/palindrome-string/
    /// </summary>
    public class PalindromeString
    {
        /*
        Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

        Example:
        "A man, a plan, a canal: Panama" is a palindrome.
        "race a car" is not a palindrome.

        Return 0 / 1 ( 0 for false, 1 for true ) for this problem
        */

        public int Solve(string A)
        {
            if (A == null)
            {
                return 0;
            }

            int start = 0, end = A.Length - 1;
            while (start < end)
            {
                while (!char.IsLetterOrDigit(A[start]) && start < end)
                {
                    start++;
                }

                while (!char.IsLetterOrDigit(A[end]) && start < end)
                {
                    end--;
                }

                if (start == end)
                {
                    return 1;
                }

                if (!IsSameLetter(A[start], A[end]))
                {
                    return 0;
                }
                start++;
                end--;
            }
            return 1;
        }

        private bool IsSameLetter(char x, char y)
        {
            return (char.ToUpper(x) == char.ToUpper(y));
        }
    }
}
