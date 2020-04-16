using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.Tests.ProblemSet.Level2.Arrays
{
    [TestClass]
    public class TusharsBirthdayPartyTests
    {
        [TestMethod]
        public void Test1()
        {
            var problem = new TusharsBirthdayParty();
            var inputPeople = new List<int> { 4, 6 };
            var inputDishes = new List<int> { 1, 3 };
            var inputCosts = new List<int> { 5, 3 };
            var expectedOutput = 14;
            var output = problem.Solve(inputPeople, inputDishes, inputCosts);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
