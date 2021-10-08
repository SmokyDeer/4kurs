using Lab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestRPN
{
    [TestClass]
    public class UnitTestCalculator
    {
        CalculatorRPN calc = new CalculatorRPN();

        [TestMethod]
        public void TestSingleInputSum()
        {
            List<string> input = new List<string> { "5", "8", "+" };
            string expected = "13";
            string actual = calc.ToSolve(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSingleInputSub()
        {
            List<string> input = new List<string> { "5", "8", "-" };
            string expected = "-3";
            string actual = calc.ToSolve(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSingleInputMultipl()
        {
            List<string> input = new List<string> { "-3", "-2", "*", "5", "+" };
            string expected = "11";
            string actual = calc.ToSolve(input);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestAllOperators()
        {
            List<string> input = new List<string> { "5", "7", "2", "/", "-", "-0.25", "*", "12", "+" };
            string expected = "11,625";
            string actual = calc.ToSolve(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestErrorCasesSequence1()
        {
            List<string> input = new List<string> { "*"};
            string expected = "A binary operator requires at least 2 numbers in the stack";
            try
            {
                calc.ToSolve(input);
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        [TestMethod]
        public void TestErrorCasesSequence2()
        {
            List<string> input = new List<string> { "5"};
            string expected = "5";
            string actual = calc.ToSolve(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestErrorCasesSequence3()
        {
            List<string> input = new List<string> { "*" };
            string expected = "A binary operator requires at least 2 numbers in the stack";
            try
            {
                calc.ToSolve(input);
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        [TestMethod]
        public void TestErrorCasesSequence4()
        {
            List<string> input = new List<string> { "0" };
            string expected = "0";
            string actual = calc.ToSolve(input);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestErrorDivideZero()
        {
            List<string> input = new List<string> { "0", "0", "/" };
            string expected = "Arithmetic error: Division by zero";
            string actual = "";
            
            try
            {
                actual = calc.ToSolve(input);
            }
            catch (InvalidOperationException e)
            {
                actual = e.Message;
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
