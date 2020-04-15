using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level2.Arrays
{
    [TestClass]
    public class FindDuplicateInArrayTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new FindDuplicateInArray();
            var input = new List<int> { 1, 2, 3, 2 };
            var expectedOutput = 2;
            var output = problem.Solve(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void Test2()
        {
            var problem = new FindDuplicateInArray();
            var input = new List<int> { 1, 3, 3, 3 };
            var expectedOutput = 3;
            var output = problem.Solve(input);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
