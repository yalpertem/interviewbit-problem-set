using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.TwoPointers
{
    /// <summary>
    /// Minimize the absolute difference
    /// https://www.interviewbit.com/problems/minimize-the-absolute-difference/
    /// </summary>
    public class MinimizeTheAbsoluteDifference
    {
        /*
        Given three sorted arrays A, B and Cof not necessarily same sizes.
        Calculate the minimum absolute difference between the maximum and minimum number from the triplet a, b, c such that a, b, c belongs arrays A, B, C respectively.
        i.e. minimize | max(a,b,c) - min(a,b,c) |.

        Example :
        Input:
        A : [ 1, 4, 5, 8, 10 ]
        B : [ 6, 9, 15 ]
        C : [ 2, 3, 6, 6 ]
        Output:
        1

        Explanation: We get the minimum difference for a=5, b=6, c=6 as | max(a,b,c) - min(a,b,c) | = |6-5| = 1.
        */

        public int Solve(List<int> A, List<int> B, List<int> C)
        {
            int i = 0, j = 0, k = 0;
            long allMin = int.MaxValue;
            long curMin;
            while (!(IsAtEnd(A, i) && IsAtEnd(B, j) && IsAtEnd(C, k)))
            {
                curMin = GetMinimumAbsDiff(A, B, C, i, j, k);
                allMin = Math.Min(allMin, curMin);
                if (k < C.Count - 1 &&
                    (C[k] <= B[j] || IsAtEnd(B, j)) &&
                    (C[k] <= A[i] || IsAtEnd(A, i)))
                {
                    k++;
                }
                else if (j < B.Count - 1 &&
                  (B[j] <= C[k] || IsAtEnd(C, k)) &&
                  (B[j] <= A[i] || IsAtEnd(A, i)))
                {
                    j++;
                }
                else if (i < A.Count - 1 &&
                  (A[i] <= C[k] || IsAtEnd(C, k)) &&
                  (A[i] <= B[j] || IsAtEnd(B, j)))
                {
                    i++;
                }
                else if (IsAtEnd(A, i) && IsAtEnd(B, j))
                {
                    k++;
                }
                else if (IsAtEnd(A, i) && IsAtEnd(C, k))
                {
                    j++;
                }
                else if (IsAtEnd(C, k) && IsAtEnd(B, j))
                {
                    i++;
                }
            }
            curMin = GetMinimumAbsDiff(A, B, C, i, j, k);
            allMin = Math.Min(allMin, curMin);
            return (int)allMin;
        }

        private bool IsAtEnd(List<int> list, int index)
        {
            return index == list.Count - 1;
        }

        private long GetMinimumAbsDiff(
            List<int> A, List<int> B, List<int> C,
            int i, int j, int k)
        {
            long min = Math.Min(Math.Min(A[i], B[j]), C[k]);
            long max = Math.Max(Math.Max(A[i], B[j]), C[k]);
            long diff = Math.Abs(max - min);
            return diff;
        }
    }
}
