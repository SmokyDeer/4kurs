using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;
using Calculator.Classes;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Calc calc = new Calc();
        double delta = 1e-9;

        #region Sum
        [TestMethod]
        public void TestSumfloat()
        {
            Assert.AreEqual(5, calc.sum(2.5, 2.5), delta);
        }

        [TestMethod]
        public void TestSumInt()
        {
            Assert.AreEqual(10, calc.sum(6, 4), delta);
        }

        [TestMethod]
        public void TestSumNegFloat()
        {
            Assert.AreEqual(0, calc.sum(-2.5, 2.5), delta);
        }
        #endregion

        #region Sub

        [TestMethod]
        public void TestSubPosFloat()
        {
            Assert.AreEqual(5, calc.subtract(7.5, 2.5), delta);
        }

        [TestMethod]
        public void TestSubPosInt()
        {
            Assert.AreEqual(0, calc.subtract(15, 15), delta);
        }

        [TestMethod]
        public void TestSubFloatNegRes()
        {
            Assert.AreEqual(-5, calc.subtract(2.5, 7.5), delta);
        }

        [TestMethod]
        public void TestSubPosNegFloat()
        {
            Assert.AreEqual(12.0, calc.subtract(7.5, -4.5), delta);
        }
        
        [TestMethod]
        public void TestSubNegNegFloat()
        {
            Assert.AreEqual(-3, calc.subtract(-7.5, -4.5), delta);
        }
        
        [TestMethod]
        public void TestSubNegPosFloatNeg()
        {
            Assert.AreEqual(-12, calc.subtract(-7.5, 4.5), delta);
        }
        #endregion

        #region Div

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDiv()
        {
            calc.divide(1, 0);
        }

        [TestMethod]
        public void TestDivideNotZeroPosPos()
        {
            Assert.AreEqual(3, calc.divide(7.5, 2.5), delta);
        }
        
        [TestMethod]
        public void TestDivideNotZeroNegPos()
        {
            Assert.AreEqual(-3, calc.divide(-7.5, 2.5), delta);
        }
        
        
        [TestMethod]
        public void TestDivideNotZeroNegNeg()
        {
            Assert.AreEqual(3, calc.divide(-7.5, -2.5), delta);
        }

       

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestDivideException()
        {
            calc.divide(10, 10e-9);
        }

        #endregion

        #region Mult

        [TestMethod]
        public void TestMultiplyPosFloatInt()
        {
            Assert.AreEqual(15, calc.multiply(7.5, 2), delta);
        }

        [TestMethod]
        public void TestMultiplyFloatPosFloatInt()
        {
            Assert.AreEqual(22.5, calc.multiply(7.5, 3), delta);
        }

        [TestMethod]
        public void TestMultiplyIntPosIntFloat()
        {
            Assert.AreEqual(1, calc.multiply(10, 0.1), delta);
        }
        #endregion
    }
}
