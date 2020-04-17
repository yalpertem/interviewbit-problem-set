using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level8.Graphs
{
    /// <summary>
    /// Convert Sorted List to Binary Search Tree
    /// https://www.interviewbit.com/problems/convert-sorted-list-to-binary-search-tree/
    /// </summary>
    public class ConvertSortedListToBinarySearchTree
    {
        /*
        Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
        A height balanced BST : a height-balanced binary tree is defined as a binary tree in which 
            the depth of the two subtrees of every node never differ by more than 1. 
        
        Example :
        Given A : 1 -> 2 -> 3
        A height balanced BST  :

              2
            /   \
           1     3
        */

        public TreeNode Solve(ListNode a)
        {
            if (a == null)
            {
                return null;
            }

            if (a.next == null)
            {
                return new TreeNode(a.val);
            }

            int count = 0;
            var iterate = a;
            while (iterate != null)
            {
                count++;
                iterate = iterate.next;
            }
            var middle = count / 2;
            iterate = a;

            for (var i = 0; i < middle - 1; i++)
            {
                iterate = iterate.next;
            }

            TreeNode head = new TreeNode(iterate.next.val);
            ListNode rest = iterate.next.next;
            iterate.next = null;
            head.left = Solve(a);
            head.right = Solve(rest);
            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
    }
}
