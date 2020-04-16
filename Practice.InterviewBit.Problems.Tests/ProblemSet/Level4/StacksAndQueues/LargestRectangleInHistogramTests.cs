using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level4.StacksAndQueues;
using Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level4.StacksAndQueues
{
    [TestClass]
    public class LargestRectangleInHistogramTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new LargestRectangleInHistogram();
            var input = new List<int> { 2, 1, 5, 6, 2, 3 };
            var expectedOutput = 10;
            var output = problem.Solve(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void Test2()
        {
            var problem = new LargestRectangleInHistogram();
            var input = new List<int> { 12, 43, 65, 76, 84, 29, 95, 12, 86, 93, 100, 34, 54, 92, 82, 21, 43 };
            var expectedOutput = 258;
            var output = problem.Solve(input);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
