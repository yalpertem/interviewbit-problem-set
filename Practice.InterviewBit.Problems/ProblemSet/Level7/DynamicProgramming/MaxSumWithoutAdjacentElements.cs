using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    public class MaxSumWithoutAdjacentElements
    {
        public int adjacent(List<List<int>> A)
        {
            if (A == null || A.Count == 0 || A[0].Count == 0)
            {
                return 0;
            }
            var maxAdjacent = int.MinValue;
            if (A[0].Count < 3)
            {
                for (var i = 0; i < A.Count; i++)
                {
                    for (var j = 0; j < A[0].Count; j++)
                    {
                        maxAdjacent = Math.Max(maxAdjacent, A[i][j]);
                    }
                }
                return maxAdjacent;
            }

            var oneDimensionList = new List<int>();
            for (var i = 0; i < A[0].Count; i++)
            {
                var num = Math.Max(A[0][i], A[1][i]);
                oneDimensionList.Add(num);
            }

            var dpFromStart = GetMaxElementsFromStart(oneDimensionList);
            oneDimensionList.Reverse();
            var dpFromEnd = GetMaxElementsFromStart(oneDimensionList);
            Array.Reverse(dpFromEnd);
            oneDimensionList.Reverse();

            for (var i = 0; i < oneDimensionList.Count; i++)
            {
                Console.Write(oneDimensionList[i] + " ");
            }
            Console.WriteLine("------------");

            for (var i = 0; i < dpFromStart.Length; i++)
            {
                Console.Write(dpFromStart[i] + " ");
            }
            Console.WriteLine("");

            for (var i = 0; i < dpFromEnd.Length; i++)
            {
                Console.Write(dpFromEnd[i] + " ");
            }
            Console.WriteLine("");


            for (var i = 0; i < oneDimensionList.Count; i++)
            {
                var num = oneDimensionList[i];
                var pairCandidate = int.MinValue;
                if (i - 2 >= 0)
                {
                    pairCandidate = dpFromStart[i - 2];
                }
                if (i + 2 < dpFromEnd.Length)
                {
                    pairCandidate = Math.Max(pairCandidate, dpFromEnd[i + 2]);
                }
                maxAdjacent = Math.Max(maxAdjacent, num + pairCandidate);
            }

            return maxAdjacent;
        }

        private int[] GetMaxElementsFromStart(List<int> list)
        {
            var dp = new int[list.Count];
            dp[0] = list[0];
            for (var i = 1; i < dp.Length; i++)
            {
                dp[i] = Math.Max(dp[i], list[i]);
            }
            return dp;
        }
    }
}
