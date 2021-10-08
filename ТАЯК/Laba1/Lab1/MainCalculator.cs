using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    static public class MainCalculator
    {
        static CalculatorRPN _calculatorRPN = new CalculatorRPN();
        public static string Calc(string line)
        {
            string result = string.Empty;
            string RPNLine = Converter.InfixToPostfix(line);
            var operators = RPNLine.Split(' ');
            result = _calculatorRPN.ToSolve(operators.ToList());
            return result;
        }
    }
}
