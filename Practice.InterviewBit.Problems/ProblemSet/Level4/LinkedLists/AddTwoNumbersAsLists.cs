using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level4.LinkedLists
{
    /// <summary>
    /// Add Two Numbers as Lists
    /// https://www.interviewbit.com/problems/add-two-numbers-as-lists/
    /// </summary>
    public class AddTwoNumbersAsLists
    {
        /*
        You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

        Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 0 -> 8
        342 + 465 = 807

        Make sure there are no trailing zeros in the output list
        So, 7 -> 0 -> 8 -> 0 is not a valid response even though the value is still 807.
        */

        public ListNode Solve(ListNode A, ListNode B)
        {
            var head = new ListNode(0);
            var carry = 0;
            var iterate = head;
            while (A != null || B != null)
            {
                int sum;
                if (A != null && B != null)
                {
                    sum = A.val + B.val + carry;
                    A = A.next;
                    B = B.next;
                }
                else if (A == null)
                {
                    sum = B.val + carry;
                    B = B.next;
                }
                else
                {
                    sum = A.val + carry;
                    A = A.next;
                }
                carry = sum / 10;
                ListNode temp = new ListNode(sum % 10);
                iterate.next = temp;
                iterate = iterate.next;
            }

            if (carry > 0)
            {
                var extraDigit = new ListNode(carry);
                iterate.next = extraDigit;
            }

            return head.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }
    }
}
