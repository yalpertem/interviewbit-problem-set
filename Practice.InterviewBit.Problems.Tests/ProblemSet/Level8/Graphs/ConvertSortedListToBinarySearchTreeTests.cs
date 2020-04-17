using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level8.Graphs;
using System;
using System.Collections.Generic;
using System.Text;
using static Practice.InterviewBit.Problems.ProblemSet.Level8.Graphs.ConvertSortedListToBinarySearchTree;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level8.Graphs
{
    [TestClass]
    public class ConvertSortedListToBinarySearchTreeTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new ConvertSortedListToBinarySearchTree();
            var input = GetInput1();
            var expectedOutput = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var output = problem.Solve(input);
            var traversal = new List<int>();
            InOrderTraversal(output, traversal);
            CollectionAssert.AreEqual(expectedOutput, traversal);
        }

        private void InOrderTraversal(TreeNode head, List<int> traversal)
        {
            if (head == null)
            {
                return;
            }
            InOrderTraversal(head.left, traversal);
            traversal.Add(head.val);
            InOrderTraversal(head.right, traversal);
        }

        private ListNode GetInput1()
        {
            return new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                            {
                                next = new ListNode(6)
                                {
                                    next = new ListNode(7)
                                    {
                                        next = new ListNode(8)
                                        {
                                            next = new ListNode(9)
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
