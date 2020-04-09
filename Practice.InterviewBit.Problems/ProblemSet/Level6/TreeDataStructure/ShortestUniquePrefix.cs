using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level6.TreeDataStructure
{
    /// <summary>
    /// Shortest Unique Prefix
    /// https://www.interviewbit.com/problems/shortest-unique-prefix/
    /// </summary>
    public class ShortestUniquePrefix
    {
        /*
        Find shortest unique prefix to represent each word in the list.

        Example:
        Input: [zebra, dog, duck, dove]
        Output: {z, dog, du, dov}
        where we can see that
        zebra = z
        dog = dog
        duck = du
        dove = dov
        NOTE : Assume that no word is prefix of another. In other words, the representation is always possible. 
        */

        public List<string> Solve(List<string> words)
        {
            var trie = GenerateTrie(words);
            var prefixList = FindPrefixes(words, trie);
            return prefixList;
        }

        private List<string> FindPrefixes(List<string> words, Trie trie)
        {
            var prefixList = new List<string>();
            for (var i = 0; i < words.Count; i++)
            {
                var iterate = trie;

                for (var j = 0; j < words[i].Length; j++)
                {
                    var currentChar = words[i][j];
                    iterate = iterate.FollowUp[currentChar];
                    if (iterate.FollowUp.Count == 0 ||
                        (iterate.FollowUp.Count == 1 && iterate.FollowUp[words[i][j + 1]].Count == 1))
                    {
                        prefixList.Add(words[i].Substring(0, j + 1));
                        break;
                    }
                }
            }
            return prefixList;
        }

        private Trie GenerateTrie(List<string> words)
        {
            var head = new Trie();
            for (var i = 0; i < words.Count; i++)
            {
                var iterate = head;
                for (var j = 0; j < words[i].Length; j++)
                {
                    var currentChar = words[i][j];
                    if (!iterate.FollowUp.ContainsKey(currentChar))
                    {
                        iterate.FollowUp.Add(currentChar, new Trie());
                    }
                    else
                    {
                        iterate.FollowUp[currentChar].Count += 1;
                    }
                    iterate = iterate.FollowUp[currentChar];
                }
                iterate.IsWord = true;
            }
            return head;
        }

        private class Trie
        {
            public Dictionary<char, Trie> FollowUp;
            public bool IsWord;
            public int Count;
            public Trie()
            {
                FollowUp = new Dictionary<char, Trie>();
                IsWord = false;
                Count = 1;
            }
        }
    }
}
