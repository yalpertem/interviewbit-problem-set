using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Math
{
    /// <summary>
    /// Grid Unique Paths
    /// https://www.interviewbit.com/problems/grid-unique-paths/
    /// </summary>
    public class GridUniquePaths
    {
        /*
        A robot is located at the top-left corner of an A x B grid (marked ‘Start’ in the diagram below).
        The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked ‘Finish’ in the diagram below).

        How many possible unique paths are there?

        Note: A and B will be such that the resulting answer fits in a 32 bit signed integer.

        Example :
        Input : A = 2, B = 2
        Output : 2
        2 possible routes : 
            (0, 0) -> (0, 1) -> (1, 1) 
            (0, 0) -> (1, 0) -> (1, 1)
        */

        public int Solve(int width, int height)
        {
            if (width == 1) return 1;
            if (height == 1) return 1;
            var totalSteps = width + height - 2;
            var minDirectionSteps = System.Math.Min(width - 1, height - 1);
            var maxDirectionSteps = System.Math.Max(width - 1, height - 1);
            long totalOptions = 1;

            for (var i = totalSteps; i > maxDirectionSteps; i--)
            {
                totalOptions *= i;
            }

            totalOptions /= Factorial(minDirectionSteps);

            return (int)totalOptions;
        }

        private long Factorial(int A)
        {
            if (A == 0)
            {
                return 1;
            }
            return A * Factorial(A - 1);
        }
    }
}
