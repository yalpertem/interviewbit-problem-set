using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level8.Graphs
{
    /// <summary>
    /// Level Order
    /// https://www.interviewbit.com/problems/level-order/
    /// </summary>
    public class LevelOrder
    {
        /*
        Given a binary tree, return the level order traversal of its nodes’ values. (ie, from left to right, level by level).
        
        Example :
        Given binary tree

            3
           / \
          9  20
            /  \
           15   7
        return its level order traversal as:

        [
          [3],
          [9,20],
          [15,7]
        ]
        Also think about a version of the question where you are asked to do a level order traversal of the tree when depth of the tree 
        is much greater than number of nodes on a level.
        */

        public List<List<int>> Solve(TreeNode A)
        {
            var result = new List<List<int>>();
            if (A == null)
            {
                return result;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(A);
            while (queue.Count > 0)
            {
                var tempQueue = new Queue<TreeNode>();
                var levelTraversal = new List<int>();
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    levelTraversal.Add(node.val);

                    if (node.left != null)
                    {
                        tempQueue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        tempQueue.Enqueue(node.right);
                    }
                }
                queue = tempQueue;
                result.Add(levelTraversal);
            }
            return result;
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
