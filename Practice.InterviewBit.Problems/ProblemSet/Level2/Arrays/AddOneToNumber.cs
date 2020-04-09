using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays
{
    /// <summary>
    /// Add One To Number
    /// https://www.interviewbit.com/problems/add-one-to-number/
    /// </summary>
    public class AddOneToNumber
    {
        /*
        Given a non-negative number represented as an array of digits, add 1 to the number (increment the number represented by the digits).

        The digits are stored such that the most significant digit is at the head of the list.

        Example:
        If the vector has [1, 2, 3]
        the returned vector should be [1, 2, 4]
        as 123 + 1 = 124.

        NOTE: Certain things are intentionally left unclear in this question which you should practice asking the interviewer.
        For example, for this problem, following are some good questions to ask :
        Q : Can the input have 0’s before the most significant digit. Or in other words, is 0 1 2 3 a valid input?
        A : For the purpose of this question, YES
        Q : Can the output have 0’s before the most significant digit? Or in other words, is 0 1 2 4 a valid output?
        A : For the purpose of this question, NO. Even if the input has zeroes before the most significant digit.
        
         */

        public List<int> Solve(List<int> A)
        {
            var response = new List<int>();
            var carry = 0;
            var startIndex = 0;

            // to pass the leading zeros
            while (startIndex < A.Count && A[startIndex] == 0)
            {
                startIndex++;
            }

            // return 1 if full of zeros
            if (startIndex == A.Count)
            {
                response.Add(1);
                return response;
            }

            // increment every digit
            for (var i = A.Count - 1; i >= startIndex; i--)
            {
                var incrementedDigit = A[i] + carry;
                if (i == A.Count - 1)
                {
                    incrementedDigit++;
                }

                carry = (incrementedDigit == 10) ? 1 : 0;
                response.Add(incrementedDigit % 10);
            }

            // add if carry exists
            if (carry > 0)
            {
                response.Add(carry);
            }

            response.Reverse();
            return response;
        }
    }
}
