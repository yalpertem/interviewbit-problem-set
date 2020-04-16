using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level7.DynamicProgramming
{
    [TestClass]
    public class MaxRectangleInBinaryMatrixTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new MaxRectangleInBinaryMatrix();
            var input = new List<List<int>> {
                new List<int>() { 1, 1, 1 },
                new List<int>() { 0, 1, 1 },
                new List<int>() { 1, 0, 0 }

            };
            var expectedOutput = 4;
            var output = problem.Solve(input);
            Assert.AreEqual(expectedOutput, output);
        }

        public void Test2()
        {
            var problem = new MaxRectangleInBinaryMatrix();
            var input = new List<List<int>> {
                new List<int>() { 1, 1, 0, 0 },
                new List<int>() { 1, 1, 0, 1 },
                new List<int>() { 1, 1, 1, 1 },
                new List<int>() { 1, 1, 1, 0 }

            };
            var expectedOutput = 6;
            var output = problem.Solve(input);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
