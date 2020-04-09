using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays
{
    /// <summary>
    /// Set Matrix Zeros
    /// https://www.interviewbit.com/problems/set-matrix-zeros/
    /// </summary>
    public class SetMatrixZeros
    {
        /*
        Given a matrix, A of size M x N of 0s and 1s. If an element is 0, set its entire row and column to 0.
        Note: This will be evaluated on the extra memory used. Try to minimize the space and time complexity.

        Input Format:
        The first and the only argument of input contains a 2-d integer matrix, A, of size M x N.

        Output Format:
        Return a 2-d matrix that satisfies the given conditions.

        Constraints:
        1 <= N, M <= 1000
        0 <= A[i][j] <= 1

        Examples:

        Input 1:
        [   [1, 0, 1],
        [1, 1, 1], 
        [1, 1, 1]   ]
        Output 1:
        [   [0, 0, 0],
        [1, 0, 1],
        [1, 0, 1]   ]

        Input 2:
        [   [1, 0, 1],
        [1, 1, 1],
        [1, 0, 1]   ]
        Output 2:
        [   [0, 0, 0],
        [1, 0, 1],
        [0, 0, 0]   ]

        (Only Java solutions are accepted)

        public void setZeroes(ArrayList<ArrayList<Integer>> a) {
            int height = a.size();
            int width = a.get(0).size();
        
            for (int j = 0; j < width; j++) {
                for (int i = 0; i < height; i++) {
                    if (a.get(i).get(j) == 0) {
                        // current col has a zero
                        int currentVal = a.get(0).get(j);
                        a.get(0).set(j, currentVal + 100);
                        //System.out.println("Col " + i + " has zero.");
                        break;
                    }
                }
            }

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (a.get(i).get(j) % 100 == 0) {
                        // current row has a zero
                        int currentVal = a.get(i).get(0);
                        a.get(i).set(0, currentVal + 10);
                        //System.out.println("Row " + j + " has zero.");
                        break;
                    }
                }
            }
        
            for(int i = 1; i < height; i++) {
                for(int j = 1; j < width; j++) {
                    if (a.get(0).get(j) > 1 || a.get(i).get(0) > 1) {
                        a.get(i).set(j, 0);
                    }
                }
            }
        
            //fix storage
            boolean firstRowHasZero = a.get(0).get(0) % 100 >= 10;
            for (int j = 1; j < width; j++) {
                if (firstRowHasZero || a.get(0).get(j) >= 100) {
                    a.get(0).set(j, 0);
                }
            }
        
            boolean firstColHasZero = a.get(0).get(0) >= 100;
            for (int i = 1; i < height; i++) {
                if (firstColHasZero || a.get(i).get(0) >= 10) {
                    a.get(i).set(0, 0);
                }
            }
        
            if (firstRowHasZero || firstColHasZero) {
                a.get(0).set(0, 0);
                return;
            }
        
            int initialPointVal = a.get(0).get(0);
            if (initialPointVal >= 100) {
                initialPointVal -= 100;
            }
            if (initialPointVal >= 10) {
                initialPointVal -= 10;
            }
            a.get(0).set(0, initialPointVal);
        
            return;
        }
        */


    }
}
