using System;

namespace Lab1.Operators
{
    /**
     * @class AdditionOperator      Implementation of an RPN calculator addition operator (binary operator)
     * 
     * This class provides an implementation of an addition (+) operator by overriding the appropriate BinaryOpeartor abstract methods
     * 
     * @author      Ofer Tal
     * @see         Operator
     * @see         BinaryOperator
     **/
    public class AdditionOperator : BinaryOperator
    {
        /**
         * Identify the addition operator triggering token ("+")
         * @param input     the user input token
         * @returns         true iff the input token is the triggering string for this operation
         **/
        public override bool IsTriggeringInput(string input)
        {
            return (input == "+");
        }

        /**
         * Implementation of the addition operator calculation
         * 
         * @param right     the right-hand side operand of the operator
         * @param left      the left-hand side operand of the operator
         * @returns         the result of the operator
         * @throws          Exception (IllegalOperationException recommended) if any error occurred
         **/
        public override decimal Calculate(decimal left, decimal right)
        {
            return left + right;
        }
    }
}
