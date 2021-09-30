using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class Calc : ICalculator
    {
        public double divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            else if(Math.Abs(b) < 10e-8)
                throw new ArithmeticException();
            return a / b;
        }

        public double multiply(double a, double b)
        {
            return a * b;
        }

        public double subtract(double a, double b)
        {
            return a - b;
        }

        public double sum(double a, double b)
        {
            return a + b;
        }
    }
}
