using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level2.Arrays
{
    [TestClass]
    public class MaxNonNegativeSubArrayTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new MaxNonNegativeSubArray();
            var input = new List<int> { 1, 2, 5, -7, 2, 3 };
            var expectedOutput = new List<int> { 1, 2, 5 };
            var output = problem.Solve(input);
            CollectionAssert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void Test2()
        {
            var problem = new MaxNonNegativeSubArray();
            var input = new List<int> { 10, -1, 2, 3, -4, 100 };
            var expectedOutput = new List<int> { 100 };
            var output = problem.Solve(input);
            CollectionAssert.AreEqual(expectedOutput, output);
        }
    }
}
