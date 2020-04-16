using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level4.StacksAndQueues
{
    /// <summary>
    /// Largest Rectangle in Histogram
    /// https://www.interviewbit.com/problems/largest-rectangle-in-histogram/
    /// </summary>
    public class LargestRectangleInHistogram
    {
        /*
        Given an array of integers A of size N. A represents a histogram i.e A[i] denotes height of
        the ith histogram’s bar. Width of each bar is 1.
        Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].
        The largest rectangle is shown in the shaded area, which has area = 10 unit.
        Find the area of largest rectangle in the histogram.

        Input Format
        The only argument given is the integer array A.
        Output Format
        Return the area of largest rectangle in the histogram.
        
        For Example
        Input 1:
            A = [2, 1, 5, 6, 2, 3]
        Output 1:
            10
        Explanation 1:
        The largest rectangle is shown in the shaded area, which has area = 10 unit.
        */

        public int Solve(List<int> bars)
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
