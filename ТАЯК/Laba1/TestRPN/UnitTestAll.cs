using Lab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestRPN
{
    [TestClass]
    public class UnitTest2
    {
        
        [TestMethod]
        public void TestMethodSum()
        {
            var actual = MainCalculator.Calc("1+2");
            var expected = "3";
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMethodSumFloat()
        {
            var actual = MainCalculator.Calc("0.1+0.2");
            var expected = "0,3";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodMinus()
        {
            var actual = MainCalculator.Calc("1-2");
            var expected = "-1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodMinusFloat()
        {
            var actual = MainCalculator.Calc("0.1-0.2");
            var expected = "-0,1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodNegative()
        {
            var actual = MainCalculator.Calc("-1-2");
            var expected = "-3";
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMethodNegativeFloat()
        {
            var actual = MainCalculator.Calc("-0.1-0.2");
            var expected = "-0,3";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodMultiplyPositive()
        {
            var actual = MainCalculator.Calc("7*6");
            var expected = "42";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodMultiplyNegative()
        {
            var actual = MainCalculator.Calc("-7*6");
            var expected = "-42";
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMethodSubPos()
        {
            var actual = MainCalculator.Calc("42/6");
            var expected = "7";
            Assert.AreEqual(expected, actual);
        }
    }
}
