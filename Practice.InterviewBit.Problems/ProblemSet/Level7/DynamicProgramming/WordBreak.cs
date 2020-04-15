using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Word Break
    /// https://www.interviewbit.com/problems/word-break/
    /// </summary>
    public class WordBreak
    {
        /*
        Given a string A and a dictionary of words B, determine if A can be segmented into a space-separated sequence of one or more dictionary words.

        Input Format:
        The first argument is a string, A.
        The second argument is an array of strings, B.
        
        Output Format:
        Return 0 / 1 ( 0 for false, 1 for true ) for this problem.
        
        Constraints:
        1 <= len(A) <= 6500
        1 <= len(B) <= 10000
        1 <= len(B[i]) <= 20

        Examples:

        Input 1:
            A = "myinterviewtrainer",
            B = ["trainer", "my", "interview"]
        Output 1:
            1
        Explanation 1:
            Return 1 ( corresponding to true ) because "myinterviewtrainer" can be segmented as "my interview trainer".
    
        Input 2:
            A = "a"
            B = ["aaa"]
        Output 2:
            0
        Explanation 2:
            Return 0 ( corresponding to false ) because "a" cannot be segmented as "aaa".

        */

        private int _maxWordLength = 0;
        private int[] _dp;
        private HashSet<string> _words;

        public int Solve(string text, List<string> words)
        {
            InitializeWordsSet(words);
            InitializeDP(text);
            var isValid = IsValidWordBreak(text, 0);
            return isValid ? 1 : 0;
        }

        private bool IsValidWordBreak(string text, int start)
        {
            if (_dp[start] != -1)
            {
                return _dp[start] == 1;
            }

            var end = start;
            while (end - start + 1 <= _maxWordLength && end < text.Length)
            {
                var subStr = text.Substring(start, end - start + 1);
                if (_words.Contains(subStr))
                {
                    var isValid = (end == text.Length - 1) || IsValidWordBreak(text, end + 1);
                    if (isValid)
                    {
                        _dp[start] = 1;
                        return true;
                    }
                }
                end++;
            }
            _dp[start] = 0;
            return false;
        }

        private void InitializeWordsSet(List<string> B)
        {
            _maxWordLength = 0;
            _words = new HashSet<string>();
            for (var i = 0; i < B.Count; i++)
            {
                if (!_words.Contains(B[i]))
                {
                    _words.Add(B[i]);
                }
                _maxWordLength = Math.Max(_maxWordLength, B[i].Length);
            }
        }

        private void InitializeDP(string A)
        {
            _dp = new int[A.Length];
            for (var i = 0; i < A.Length; i++)
            {
                _dp[i] = -1;
            }
        }
    }
}
