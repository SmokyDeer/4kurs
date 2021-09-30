using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;
using Calculator.Classes;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        double delta = 1e-9;

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDiv()
        {
            Calc calc = new Calc();
            calc.divide(1, 0);
        }

        [TestMethod]
        public void TestSum()
        {
            Calc calc = new Calc();

            Assert.AreEqual(5, calc.sum(2.5, 2.5), delta);
            Assert.AreEqual(5, calc.sum(2.5, 2.5), delta);
            Assert.AreEqual(10, calc.sum(6, 4), delta);
            Assert.AreEqual(0, calc.sum(-2.5, 2.5), delta);
            Assert.AreEqual(8, calc.sum(3.7, 4.3), delta);
        }  

        [TestMethod]
        public void TestSub()
        {
            Calc calc = new Calc();

            Assert.AreEqual(5, calc.subtract(7.5, 2.5), delta);
            Assert.AreEqual(0, calc.subtract(15, 15), delta);
            Assert.AreEqual(-5, calc.subtract(2.5, 7.5), delta);
            Assert.AreEqual(12.0, calc.subtract(7.5, -4.5), delta);
            Assert.AreEqual(-3, calc.subtract(-7.5, -4.5), delta);
            Assert.AreEqual(-12, calc.subtract(-7.5, 4.5), delta);
        }  
        
        [TestMethod]
        public void TestDivideNotZero()
        {
            Calc calc = new Calc();

            Assert.AreEqual(3, calc.divide(7.5, 2.5), delta);
            Assert.AreEqual(-3, calc.divide(-7.5, 2.5), delta);
            Assert.AreEqual(3, calc.divide(-7.5, -2.5), delta);
        } 
        
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestDivideException()
        {
            Calc calc = new Calc();

            calc.divide(10, 10e-9);
        }


        [TestMethod]
        public void TestMultiply()
        {
            Calc calc = new Calc();

            Assert.AreEqual(15, calc.multiply(7.5, 2), delta);
            Assert.AreEqual(22.5, calc.multiply(7.5, 3), delta);
            Assert.AreEqual(1, calc.multiply(10, 0.1), delta);
        }
    }
}
