using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Coins in a Line
    /// https://www.interviewbit.com/problems/coins-in-a-line/
    /// </summary>
    public class CoinsInALine
    {
        /*
        There are A coins (Assume A is even) in a line.
        Two players take turns to take a coin from one of the ends of the line until there are no more coins left.
        The player with the larger amount of money wins.
        Assume that you go first.
        Return the maximum amount of money you can win.

        Input Format:
        The first and the only argument of input contains an integer array, A.
        Output Format:
        Return an integer representing the maximum amount of money you can win.
        
        Constraints:
        1 <= length(A) <= 500
        1 <= A[i] <= 1e5
        
        Examples:

        Input 1:
            A = [1, 2, 3, 4]
        Output 1:
            6
        Explanation 1:
            You      : Pick 4
            Opponent : Pick 3
            You      : Pick 2
            Opponent : Pick 1
            Total money with you : 4 + 2 = 6

        Input 2:
            A = [5, 4, 8, 10]
        Output 2:
            15
        Explanation 2:
            You      : Pick 10
            Opponent : Pick 8
            You      : Pick 5
            Opponent : Pick 4
            Total money with you : 10 + 5 = 15
        */

        public int Solve(List<int> coins)
        {
            if (coins == null || coins.Count == 0)
            {
                return 0;
            }

            var scores = new Dictionary<CoinSet, int>(new CoinSetComparer());
            var result = GetScore(coins, 0, coins.Count - 1, scores);
            return result;
        }

        private int GetScore(List<int> coins, int start, int end, Dictionary<CoinSet, int> scores)
        {
            if (start >= end)
            {
                return 0;
            }

            var coinSet = new CoinSet(start, end);
            if (scores.ContainsKey(coinSet))
            {
                return scores[coinSet];
            }

            var take1 = coins[start];
            var score11 = GetScore(coins, start + 2, end, scores);
            var score12 = GetScore(coins, start + 1, end - 1, scores);
            var score1Min = take1 + Math.Min(score11, score12); // the opponent is as smart as you :)

            var take2 = coins[end];
            var score21 = GetScore(coins, start, end - 2, scores);
            var score22 = score12;
            var score2Min = take2 + Math.Min(score21, score22);

            var scoreMax = Math.Max(score1Min, score2Min);
            scores.Add(new CoinSet(start, end), scoreMax);
            return scoreMax;
        }

        private class CoinSet
        {
            public int Start;
            public int End;
            public CoinSet() { }
            public CoinSet(int start, int end)
            {
                Start = start;
                End = end;
            }
        }

        private class CoinSetComparer : IEqualityComparer<CoinSet>
        {
            public bool Equals(CoinSet x, CoinSet y)
            {
                return x.Start == y.Start && x.End == y.End;
            }

            public int GetHashCode(CoinSet x)
            {
                return x.Start.GetHashCode() + x.End.GetHashCode();
            }
        }
    }
}
