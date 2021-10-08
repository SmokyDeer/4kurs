using System;

namespace Lab1.Operators
{
    /**
     * @class DivisionOperator      Implementation of an RPN calculator division operator (binary operator)
     * 
     * This class provides an implementation of an division (/) operator by overriding the appropriate BinaryOpeartor abstract methods
     * 
     * @author      Ofer Tal
     * @see         Operator
     * @see         BinaryOperator
     **/
    public class DivisionOperator : BinaryOperator
    {
        /**
         * Identify the division operator triggering token ("/")
         * @param input     the user input token
         * @returns         true iff the input token is the triggering string for this operation
         **/
        public override bool IsTriggeringInput(string input)
        {
            return (input == "/");
        }

        /**
         * Implementation of the division operator calculation
         * 
         * @param right     the right-hand side operand of the operator
         * @param left      the left-hand side operand of the operator
         * @returns         the result of the operator
         * @throws          Exception (IllegalOperationException recommended) if any error occurred
         **/
        public override decimal Calculate(decimal left, decimal right)
        {
            // identify error condition - division by zero (although just perforing the calculation will also throw an exception, this way we are more explicit and are in control of the error message)
            if (right == 0)
            {
                throw new InvalidOperationException("Arithmetic error: Division by zero");
            }
            return left / right;
        }
    }
}
