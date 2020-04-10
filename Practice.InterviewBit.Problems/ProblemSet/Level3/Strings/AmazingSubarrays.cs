using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.Strings
{
    /// <summary>
    /// Amazing Subarrays
    /// https://www.interviewbit.com/problems/amazing-subarrays/
    /// </summary>
    public class AmazingSubarrays
    {
        /*
        You are given a string S, and you have to find all the amazing substrings of S.
        Amazing Substring is one that starts with a vowel (a, e, i, o, u, A, E, I, O, U).

        Input
        Only argument given is string S.
        Output
        Return a single integer X mod 10003, here X is number of Amazing Substrings in given string.
        
        Constraints
        1 <= length(S) <= 1e6
        S can have special characters
        
        Example

        Input
            ABEC
        Output
            6

        Explanation
	        Amazing substrings of given string are :
	        1. A
	        2. AB
	        3. ABE
	        4. ABEC
	        5. E
	        6. EC
	        here number of substrings are 6 and 6 % 10003 = 6.
        */

        public int Solve(string A)
        {
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            var total = 0;
            for (var i = 0; i < A.Length; i++)
            {
                if (IsVowel(A[i]))
                {
                    total = (total + (A.Length - i)) % 10003;
                }
            }
            return total;
        }

        private bool IsVowel(char c)
        {
            var cUpper = Char.ToUpper(c);
            return vowels.Contains(cUpper);
        }

        private readonly List<char> vowels = new List<char> { 'A', 'E', 'I', 'O', 'U' };
    }
}
