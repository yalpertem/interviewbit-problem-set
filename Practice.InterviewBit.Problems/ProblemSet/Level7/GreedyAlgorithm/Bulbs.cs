﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.GreedyAlgorithm
{
    /// <summary>
    /// Bulbs
    /// https://www.interviewbit.com/problems/bulbs/
    /// </summary>
    public class Bulbs
    {
        /*
        N light bulbs are connected by a wire.
        Each bulb has a switch associated with it, however due to faulty wiring, a switch also changes the state of all the bulbs to the right of current bulb.
        Given an initial state of all bulbs, find the minimum number of switches you have to press to turn on all the bulbs.
        You can press the same switch multiple times.
        Note : 0 represents the bulb is off and 1 represents the bulb is on.

        Input Format:
        The first and the only argument contains an integer array A, of size N.

        Output Format:
        Return an integer representing the minimum number of switches required.

        Constraints:
        1 <= N <= 5e5
        0 <= A[i] <= 1

        Example:

        Input 1:
            A = [1]
        Output 1:
            0
        Explanation 1:
        There is no need to turn any switches as all the bulbs are already on.
        Input 2: 
            A = [0 1 0 1]
        Output 2:
            4
        Explanation 2:
	    press switch 0 : [1 0 1 0]
	    press switch 1 : [1 1 0 1]
	    press switch 2 : [1 1 1 0]
	    press switch 3 : [1 1 1 1]
        */

        public int Solve(List<int> bulbs)
        {
            if (bulbs == null || bulbs.Count == 0)
            {
                return 0;
            }
            var total = 0;
            bool isReverse = false;
            for (var i = 0; i < bulbs.Count; i++)
            {
                var current = isReverse ? 1 - bulbs[i] : bulbs[i];
                if (current == 0)
                {
                    total++;
                    isReverse = !isReverse;
                }
            }
            return total;
        }
    }
}
