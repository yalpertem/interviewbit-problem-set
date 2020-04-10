using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level6.TreeDataStructure
{
    /// <summary>
    /// Hotel Reviews
    /// https://www.interviewbit.com/problems/hotel-reviews/
    /// </summary>
    public class HotelReviews
    {
        public List<int> Solve(string A, List<string> B)
        {
            var result = new List<int>();
            if (B == null || B.Count == 0)
            {
                return result;
            }

            var goodWords = GenerateTrie(A);
            var countList = new List<CountItem>();
            for (var i = 0; i < B.Count; i++)
            {
                var count = GetOccurences(B[i], goodWords);
                countList.Add(new CountItem(i, count));
            }
            countList.Sort();
            for (var i = 0; i < countList.Count; i++)
            {
                result.Add(countList[i].Index);
            }

            return result;
        }

        private int GetOccurences(string text, Trie trie)
        {
            var totalCount = 0;
            var head = trie;
            for (var i = 0; i < text.Length; i++)
            {
                var letter = text[i];
                if (letter == '_')
                {
                    if (trie.IsWord)
                    {
                        totalCount++;
                    }
                    trie = head;
                }
                else
                {
                    if (trie.NextSet.ContainsKey(letter))
                    {
                        trie = trie.NextSet[letter];
                    }
                    else
                    {
                        trie = head;
                        while (i < text.Length && text[i] != '_')
                        {
                            i++;
                        }
                    }

                }
                if (i + 1 == text.Length)
                {
                    if (trie.IsWord)
                    {
                        totalCount++;
                    }
                }
            }
            return totalCount;
        }

        private Trie GenerateTrie(string text)
        {
            var trie = new Trie();
            var head = trie;
            for (var i = 0; i < text.Length; i++)
            {
                var letter = text[i];
                if (letter == '_')
                {
                    trie.IsWord = true;
                    trie = head;
                }
                else
                {
                    if (!trie.NextSet.ContainsKey(letter))
                    {
                        trie.NextSet.Add(letter, new Trie());
                    }
                    trie = trie.NextSet[letter];
                }
                if (i + 1 == text.Length)
                {
                    trie.IsWord = true;
                }
            }
            return head;
        }

        private class Trie
        {
            public Dictionary<char, Trie> NextSet;
            public bool IsWord;
            public Trie()
            {
                NextSet = new Dictionary<char, Trie>();
                IsWord = false;
            }
        }

        private class CountItem : IComparable<CountItem>
        {
            public int Index;
            public int Count;
            public CountItem() { }
            public CountItem(int index, int count)
            {
                Index = index;
                Count = count;
            }

            public int CompareTo(CountItem compareItem)
            {
                if (Count == compareItem.Count)
                {
                    return Index.CompareTo(compareItem.Index);
                }
                return compareItem.Count.CompareTo(Count);
            }
        }
    }
}
