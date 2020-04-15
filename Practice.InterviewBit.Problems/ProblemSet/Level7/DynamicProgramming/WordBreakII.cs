using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Word Break II
    /// https://www.interviewbit.com/problems/word-break-ii/
    /// </summary>
    public class WordBreakII
    {
        /*
        Given a string A and a dictionary of words B, add spaces in A to construct a sentence where each word is a valid dictionary word.
        Return all such possible sentences.
        Note : Make sure the strings are sorted in your result.

        Input Format:
        The first argument is a string, A.
        The second argument is an array of strings, B.
        Output Format:
        Return a vector of strings representing the answer as described in the problem statement.
        Constraints:
        1 <= len(A) <= 50
        1 <= len(B) <= 25
        1 <= len(B[i]) <= 20
        
        Examples:
        
        Input 1:
            A = "b"
            B = ["aabbb"]
        Output 1:
            []

        Input 1:
            A = "catsanddog",
            B = ["cat", "cats", "and", "sand", "dog"]
        Output 1:
            ["cat sand dog", "cats and dog"]

        */
        private int _maxWordLength = 0;
        private Dictionary<int, List<string>> _dp;
        private HashSet<string> _words;

        public List<string> Solve(string text, List<string> words)
        {
            InitializeWordsSet(words);
            _dp = new Dictionary<int, List<string>>();
            BuildCombinations(text, 0);
            var result = _dp[0] ?? new List<string>();
            return result;
        }

        private List<string> BuildCombinations(string text, int start)
        {
            if (_dp.ContainsKey(start))
            {
                return _dp[start];
            }
            var end = start;
            while (end - start + 1 <= _maxWordLength && end < text.Length)
            {
                var subStr = text.Substring(start, end - start + 1);
                if (_words.Contains(subStr))
                {
                    var list = _dp.ContainsKey(start) ?
                        _dp[start] : new List<string>();
                    if (end == text.Length - 1)
                    {
                        list.Add(subStr);
                        _dp[start] = list;
                        return _dp[start];
                    }
                    else
                    {
                        var rest = BuildCombinations(text, end + 1);
                        if (rest != null)
                        {
                            for (var i = 0; i < rest.Count; i++)
                            {
                                list.Add(subStr + " " + rest[i]);
                            }
                            _dp[start] = list;
                        }
                    }
                }
                end++;
            }
            if (!_dp.ContainsKey(start))
            {
                _dp.Add(start, null);
            }
            return _dp[start];
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
    }
}
