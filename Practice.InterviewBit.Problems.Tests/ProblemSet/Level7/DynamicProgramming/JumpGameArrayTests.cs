using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level2.Arrays
{
    [TestClass]
    public class JumpGameArrayTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new JumpGameArray();
            var input = new List<int> { 2, 3, 1, 1, 4 };
            var expectedOutput = 1;
            var output = problem.Solve(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void Test2()
        {
            var problem = new JumpGameArray();
            var input = new List<int> { 3, 2, 1, 0, 4 };
            var expectedOutput = 0;
            var output = problem.Solve(input);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
