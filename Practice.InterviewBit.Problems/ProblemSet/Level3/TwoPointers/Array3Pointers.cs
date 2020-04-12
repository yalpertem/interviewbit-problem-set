using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.TwoPointers
{
    /// <summary>
    /// Array 3 Pointers
    /// https://www.interviewbit.com/problems/array-3-pointers/
    /// </summary>
    public class Array3Pointers
    {   /*
        You are given 3 arrays A, B and C. All 3 of the arrays are sorted.
        Find i, j, k such that :
        max(abs(A[i] - B[j]), abs(B[j] - C[k]), abs(C[k] - A[i])) is minimized.
        Return the minimum max(abs(A[i] - B[j]), abs(B[j] - C[k]), abs(C[k] - A[i]))

        **abs(x) is absolute value of x and is implemented in the following manner : **
            if (x < 0) return -x;
            else return x;

        Example :
        Input : 
            A : [1, 4, 10]
            B : [2, 15, 20]
            C : [10, 12]
        Output : 5 
        With 10 from A, 15 from B and 10 from C.
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

        private long GetMinimumAbsDiff(List<int> A, List<int> B, List<int> C,
            int i, int j, int k)
        {
            long max = Math.Max(Math.Abs(A[i] - B[j]), Math.Abs(A[i] - C[k]));
            max = Math.Max(max, Math.Abs(C[k] - B[j]));
            return max;
        }
    }
}
