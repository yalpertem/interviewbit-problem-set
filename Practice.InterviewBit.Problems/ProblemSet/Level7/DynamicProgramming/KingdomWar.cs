using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Kingdom War
    /// https://www.interviewbit.com/problems/kingdom-war/
    /// </summary>
    public class KingdomWar
    {
        public int Solve(List<List<int>> matrix)
        {
            if (matrix == null || matrix[0] == null || matrix[0].Count == 0)
            {
                return 0;
            }

            var dp = GenerateSubMatrics(matrix);
            int max = FindMax(dp);
            return max;
        }

        private int[,] GenerateSubMatrics(List<List<int>> matrix)
        {
            var dp = new int[matrix.Count, matrix[0].Count];
            var bottom = matrix.Count - 1;
            var right = matrix[0].Count - 1;
            var i = bottom;
            var j = right;
            while (true)
            {
                for (var k = right; k > j; k--)
                {
                    dp[i, k] = ComputeCell(matrix, i, k, dp);
                }

                for (var k = bottom; k > i; k--)
                {
                    dp[k, j] = ComputeCell(matrix, k, j, dp);
                }

                dp[i, j] = ComputeCell(matrix, i, j, dp);

                if (i == 0 && j == 0)
                {
                    break;
                }

                if (i > 0)
                {
                    i--;
                }
                if (j > 0)
                {
                    j--;
                }
            }
            return dp;
        }

        private int ComputeCell(List<List<int>> matrix, int i, int j, int[,] dp)
        {
            var sum = 0;
            if (i + 1 < matrix.Count)
            {
                sum += dp[i + 1, j];
            }

            if (j + 1 < matrix[0].Count)
            {
                sum += dp[i, j + 1];
                if (i + 1 < matrix.Count)
                {
                    sum -= dp[i + 1, j + 1];
                }
            }
            sum += matrix[i][j];
            return sum;
        }

        private int FindMax(int[,] dp)
        {
            int max = int.MinValue;
            for (var i = 0; i < dp.GetLength(0); i++)
            {
                for (var j = 0; j < dp.GetLength(1); j++)
                {
                    max = Math.Max(max, dp[i, j]);
                }
            }
            return max;
        }
    }
}
