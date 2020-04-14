using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Max Sum Path in Binary Tree
    /// https://www.interviewbit.com/problems/max-sum-path-in-binary-tree/
    /// </summary>
    public class MaxSumPathInBinaryTree
    {
        /*
        Given a binary tree T, find the maximum path sum.
        The path may start and end at any node in the tree.

        Input Format:
        The first and the only argument contains a pointer to the root of T, A.
        Output Format:
        Return an integer representing the maximum sum path.
        Constraints:
        1 <= Number of Nodes <= 7e4
        -1000 <= Value of Node in T <= 1000
        
        Example :

        Input 1:
               1
              / \
             2   3
        Output 1:
             6
        Explanation 1:
        The path with maximum sum is: 2 -> 1 -> 3

        Input 2:
               -10
               /  \
             -20  -30
        Output 2:
            -10
        Explanation 2:
        The path with maximum sum is: -10
        */

        private int _max;
        public int Solve(TreeNode head)
        {
            _max = int.MinValue;
            if (head == null)
            {
                return 0;
            }
            GetCurrentPathSum(head);
            return _max;
        }

        private int GetCurrentPathSum(TreeNode head)
        {
            if (head == null)
            {
                return 0;
            }

            var currentMax = head.val;
            var leftPathSum = GetCurrentPathSum(head.left);
            var rightPathSum = GetCurrentPathSum(head.right);
            if (leftPathSum > 0)
            {
                currentMax += leftPathSum;
            }
            if (rightPathSum > 0)
            {
                currentMax += rightPathSum;
            }
            _max = Math.Max(_max, currentMax);

            return leftPathSum > rightPathSum ?
                head.val + Math.Max(0, leftPathSum) :
                head.val + Math.Max(0, rightPathSum);
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
