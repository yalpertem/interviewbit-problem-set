using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level4.LinkedLists
{
    /// <summary>
    /// Swap List Nodes in pairs
    /// https://www.interviewbit.com/problems/swap-list-nodes-in-pairs/
    /// </summary>
    public class SwapListNodesInPairs
    {
        /*
        Given a linked list, swap every two adjacent nodes and return its head.
        For example,
        Given 1->2->3->4, you should return the list as 2->1->4->3.
        Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.
        */

        public ListNode Solve(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var prev = head;
            var cur = head.next;
            head = cur;

            while (true)
            {
                var nextTemp = cur.next;

                cur.next = prev;

                if (nextTemp == null || nextTemp.next == null)
                {
                    prev.next = nextTemp;
                    break;
                }

                prev.next = nextTemp.next;
                prev = nextTemp;
                cur = prev.next;

            }
            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }
    }
}
