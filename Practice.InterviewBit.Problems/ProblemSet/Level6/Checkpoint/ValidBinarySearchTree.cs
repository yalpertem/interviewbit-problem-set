using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level6.Checkpoint
{
    /// <summary>
    /// Valid Binary Search Tree
    /// https://www.interviewbit.com/problems/valid-binary-search-tree/
    /// </summary>
    public class ValidBinarySearchTree
    {
        /*
        Given a binary tree, determine if it is a valid binary search tree (BST).
        Assume a BST is defined as follows:

        The left subtree of a node contains only nodes with keys less than the node’s key.
        The right subtree of a node contains only nodes with keys greater than the node’s key.
        Both the left and right subtrees must also be binary search trees.
        Example :

        Input : 
            1
           /  \
          2    3
        Output : 0 or False


        Input : 
            2
           / \
          1   3
        Output : 1 or True 

        Return 0 / 1 ( 0 for false, 1 for true ) for this problem

        */

        public class Solution
        {
            public int Solve(TreeNode node)
            {
                var isValid = IsValidBST(node, int.MinValue, int.MaxValue);
                return isValid ? 1 : 0;
            }

            public bool IsValidBST(TreeNode node, int minValue, int maxValue)
            {
                if (node == null)
                {
                    return true;
                }

                if (node.val < minValue || node.val > maxValue)
                {
                    return false;
                }

                var isLeftValid = IsValidBST(node.left, minValue, node.val - 1);
                if (!isLeftValid)
                {
                    return false;
                }

                return IsValidBST(node.right, node.val + 1, maxValue);
            }
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
