using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab1;

namespace TestRPN
{
    [TestClass]
    public class UnitTestRPN
    {
        [TestMethod]
        public void TestSingleInput1()
        {
            string input = "5+8";
            string expected = "5 8 +";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }

        public void TestSingleInput2()
        {
            string input = "5-8";
            string expected = "5 8 -";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSingleInput3()
        {
            string input = "+8+5";
            string expected = "8 + 5 +";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSingleInputNegative()
        {
            string input = "-0.1-0.2";
            string expected = "-0.1 0.2 -";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNegativeInput()
        {
            string input = "-8+5";
            string expected = "-8 5 +";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiply()
        {
            string input = "10+2*6";
            string expected = "10 2 6 * +";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        } 
        
        [TestMethod]
        public void TestMultiply2()
        {
            string input = "100*2+12";
            string expected = "100 2 * 12 +";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMultiply3()
        {
            string input = "100*(2+12)";
            string expected = "100 2 12 + *";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMultiplyDivision()
        {
            string input = "100*(2+12)/14";
            string expected = "100 2 12 + * 14 /";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMultiplyDivision2()
        {
            string input = "(4+3)-(2*7)";
            string expected = "4 3 + 2 7 * -";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSpaces()
        {
            string input = "1   +  2+3";
            string expected = "1 2 + 3 +";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFloat()
        {
            string input = "0.1+0.2";
            string expected = "0.1 0.2 +";
            string actual = Converter.InfixToPostfix(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
