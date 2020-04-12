using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level4.LinkedLists
{
    /// <summary>
    /// Partition List
    /// 
    /// </summary>
    public class PartitionList
    {
        /*
        Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
        You should preserve the original relative order of the nodes in each of the two partitions.
        For example,
        Given 1->4->3->2->5->2 and x = 3,
        return 1->2->2->4->3->5.
        */

        public ListNode Solve(ListNode A, int B)
        {
            if (A == null || A.next == null)
            {
                return A;
            }
            var iterate = A;
            var left = new ListNode(-1);
            var leftIterate = left;
            var right = new ListNode(-1);
            var rightIterate = right;

            while (iterate != null)
            {
                if (iterate.val < B)
                {
                    leftIterate.next = iterate;
                    leftIterate = leftIterate.next;
                }
                else
                {
                    rightIterate.next = iterate;
                    rightIterate = rightIterate.next;
                }
                iterate = iterate.next;
            }
            rightIterate.next = null;
            leftIterate.next = right.next;
            left = left.next;
            return left;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }
    }
}
