using System.Collections.Generic;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays
{
    /// <summary>
    /// MAXSPPROD
    /// https://www.interviewbit.com/problems/maxspprod/
    /// </summary>
    public class Maxspprod
    {
        /*
        You are given an array A containing N integers. The special product of each ith integer in this array is defined as the product of the following:<ul>
        LeftSpecialValue: For an index i, it is defined as the index j such that A[j]>A[i] (i>j). If multiple A[j]’s are present in multiple positions, the LeftSpecialValue is the maximum value of j.
        RightSpecialValue: For an index i, it is defined as the index j such that A[j]>A[i] (j>i). If multiple A[j]s are present in multiple positions, the RightSpecialValue is the minimum value of j.
        Write a program to find the maximum special product of any integer in the array.

        Input: You will receive array of integers as argument to function.
        Return: Maximum special product of any integer in the array modulo 1000000007.

        Note: If j does not exist, the LeftSpecialValue and RightSpecialValue are considered to be 0.
        Constraints:
            1 <= N <= 10^5
            1 <= A[i] <= 10^9
        */

        private List<int> _leftSpecialIndices;
        private List<int> _rightSpecialIndices;

        public int Solve(List<int> list)
        {
            var modulo = 1000000007;

            FillLeftSpecialIndices(list);
            FillRightSpecialIndices(list);
            long maxProduct = 0;

            for (var i = 0; i < _leftSpecialIndices.Count; i++)
            {
                //Console.WriteLine("For i=" + i + ", LSI:" + _leftSpecialIndices[i] + ", RSI:" + _rightSpecialIndices[i]);
                long curProduct = (long)_leftSpecialIndices[i] * _rightSpecialIndices[i];
                if (curProduct > maxProduct)
                {
                    maxProduct = curProduct;
                }
            }

            return (int)(maxProduct % modulo);
        }

        private void FillLeftSpecialIndices(List<int> list)
        {
            var indicesStack = new Stack<int>();
            _leftSpecialIndices = new List<int>();

            for (var i = 0; i < list.Count; i++)
            {
                var leftSpecialIndex = -1;

                while (indicesStack.Count > 0)
                {
                    var candidate = indicesStack.Peek();
                    if (list[candidate] > list[i])
                    {
                        leftSpecialIndex = candidate;
                        break;
                    }
                    else
                    {
                        indicesStack.Pop();
                    }
                }

                indicesStack.Push(i);
                _leftSpecialIndices.Add(leftSpecialIndex < 0 ? 0 : leftSpecialIndex);
            }
        }

        private void FillRightSpecialIndices(List<int> A)
        {
            var indicesStack = new Stack<int>();
            _rightSpecialIndices = new List<int>();

            for (var i = A.Count - 1; i >= 0; i--)
            {
                var rightSpecialIndex = -1;

                while (indicesStack.Count > 0)
                {
                    var candidate = indicesStack.Peek();
                    if (A[candidate] > A[i])
                    {
                        rightSpecialIndex = candidate;
                        break;
                    }
                    else
                    {
                        indicesStack.Pop();
                    }
                }

                indicesStack.Push(i);
                _rightSpecialIndices.Add(rightSpecialIndex < 0 ? 0 : rightSpecialIndex);
            }
            _rightSpecialIndices.Reverse();
        }
    }
}
