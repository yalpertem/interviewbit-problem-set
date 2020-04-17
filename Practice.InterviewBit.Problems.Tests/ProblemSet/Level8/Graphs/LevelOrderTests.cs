using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level8.Graphs;
using System;
using System.Collections.Generic;
using System.Text;
using static Practice.InterviewBit.Problems.ProblemSet.Level8.Graphs.LevelOrder;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level8.Graphs
{
    [TestClass]
    public class LevelOrderTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new LevelOrder();
            var input = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                    {
                        right = new TreeNode(5)
                    }
                }
            };
            var expectedOutput = new List<List<int>> {
                new List<int>() { 1, },
                new List<int>() { 2, 3 },
                new List<int>() { 4 },
                new List<int>() { 5 }
            };
            var output = problem.Solve(input);
            for (var i = 0; i < output.Count; i++)
            {
                CollectionAssert.AreEqual(expectedOutput[i], output[i]);
            }
        }
    }
}
