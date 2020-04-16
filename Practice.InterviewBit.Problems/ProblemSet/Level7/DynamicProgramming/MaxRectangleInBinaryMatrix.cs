using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Max Rectangle in Binary Matrix
    /// https://www.interviewbit.com/problems/max-rectangle-in-binary-matrix/
    /// </summary>
    public class MaxRectangleInBinaryMatrix
    {
        /*
        Given a 2D binary matrix filled with 0’s and 1’s, find the largest rectangle containing all ones and return its area.
        Bonus if you can solve it in O(n^2) or less.

        Example :
        A : [  1 1 1
               0 1 1
               1 0 0 
            ]
        Output : 4 
        As the max area rectangle is created by the 2x2 rectangle created by (0,1), (0,2), (1,1) and (1,2)
        */

        public int Solve(List<List<int>> A)
        {
            var bars = new List<int>();
            for (var j = 0; j < A[0].Count; j++)
            {
                bars.Add(A[0][j]);
            }
            var maxArea = FindLargestAreaInHistogram(bars);

            for (var i = 1; i < A.Count; i++)
            {
                MergeWithPreviousBars(bars, A[i]);
                var currentMax = FindLargestAreaInHistogram(bars);
                maxArea = Math.Max(maxArea, currentMax);
            }

            return maxArea;
        }

        private void MergeWithPreviousBars(List<int> bars, List<int> current)
        {
            for (var j = 0; j < current.Count; j++)
            {
                if (current[j] == 0)
                {
                    bars[j] = 0;
                }
                else
                {
                    bars[j] += 1;
                }
            }
        }

        private int FindLargestAreaInHistogram(List<int> bars)
        {
            var stack = new Stack<int>();
            var max = 0;
            for (var i = 0; i < bars.Count; i++)
            {
                var num = bars[i];
                while (stack.Count > 0 && bars[stack.Peek()] > num)
                {
                    var curMax = CalculateArea(bars, stack, i);
                    max = Math.Max(max, curMax);
                }
                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                int curMax = CalculateArea(bars, stack, bars.Count);
                max = Math.Max(max, curMax);
            }
            return max;
        }

        private static int CalculateArea(List<int> bars, Stack<int> stack, int i)
        {
            var old = stack.Pop();
            var length = stack.Count == 0 ? i : (i - stack.Peek() - 1);
            var curMax = bars[old] * length;
            return curMax;
        }
    }
}
