using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.Strings
{
    /// <summary>
    /// Minimum Characters required to make a String Palindromic
    /// https://www.interviewbit.com/problems/minimum-characters-required-to-make-a-string-palindromic/
    /// </summary>
    public class MinimumCharactersForPalindromic
    {
        /*
        Given an string A. The only operation allowed is to insert characters in the beginning of the string.
        Find how many minimum characters are needed to be inserted to make the string a palindrome string.
        
        Input Format
        The only argument given is string A.
        Output Format
        Return the minimum characters that are needed to be inserted to make the string a palindrome string.
        
        Examples:

        Input 1:
            A = "ABC"
        Output 1:
            2
            Explanation 1:
                Insert 'B' at beginning, string becomes: "BABC".
                Insert 'C' at beginning, string becomes: "CBABC".

        Input 2:
            A = "AACECAAAA"
        Output 2:
            2
            Explanation 2:
                Insert 'A' at beginning, string becomes: "AAACECAAAA".
                Insert 'A' at beginning, string becomes: "AAAACECAAAA".
        */

        public int Solve(string str)
        {
            var toAdd = 0;
            while (!IsPalindrome(str, str.Length - 1 - toAdd))
            {
                toAdd++;
            }
            return toAdd;
        }

        private bool IsPalindrome(string text, int end)
        {
            if (text == null)
            {
                return true;
            }

            var start = 0;
            while (start < end)
            {
                if (text[start] != text[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
    }
}
