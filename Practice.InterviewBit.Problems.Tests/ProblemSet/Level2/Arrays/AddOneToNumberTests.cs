using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level2.Arrays
{
    [TestClass]
    public class AddOneToNumberTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new AddOneToNumber();
            var input = new List<int> { 1, 4, 9 };
            var expectedOutput = new List<int> { 1, 5, 0 };
            var output = problem.Solve(input);
            CollectionAssert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void Test2()
        {
            var problem = new AddOneToNumber();
            var input = new List<int> { 0, 0, 9, 9, 9 };
            var expectedOutput = new List<int> { 1, 0, 0, 0 };
            var output = problem.Solve(input);
            CollectionAssert.AreEqual(expectedOutput, output);
        }
    }
}
