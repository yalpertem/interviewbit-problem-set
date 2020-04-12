using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level4.LinkedLists
{
    /// <summary>
    /// Reverse Link List II
    /// https://www.interviewbit.com/problems/reverse-link-list-ii/
    /// </summary>
    public class ReverseLinkListII
    {
        /*
        Reverse a linked list from position m to n. Do it in-place and in one-pass.

        For example:
        Given 1->2->3->4->5->NULL, m = 2 and n = 4,
        return 1->4->3->2->5->NULL.

        Note: Given m, n satisfy the following condition: 1 ≤ m ≤ n ≤ length of list. 
        Note 2: Usually the version often seen in the interviews is reversing the whole linked list which is obviously an easier version of this question.
        */

        public ListNode Solve(ListNode A, int B, int C)
        {
            if (A == null || A.next == null)
            {
                return A;
            }

            if (B == C)
            {
                return A;
            }

            ListNode rest = null;
            ListNode endNext = null;

            var newHead = new ListNode(-1)
            {
                next = A
            };

            var iterate = newHead;
            var i = 1;
            while (i < B)
            {
                iterate = iterate.next;
                i++;
            }

            var beginPrev = iterate;
            iterate = iterate.next;

            while (iterate != null && i <= C)
            {
                var temp = iterate.next;
                var tempRest = rest;
                rest = iterate;
                rest.next = tempRest;
                iterate = temp;
                i++;
                endNext = iterate;
            }

            beginPrev.next = rest;
            while (rest.next != null)
            {
                rest = rest.next;
            }
            rest.next = endNext;
            return newHead.next;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }

    }
}
