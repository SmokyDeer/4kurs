using System;
using System.Collections.Generic;


namespace Lab1.Operators
{
    /**
     * @class BinaryOperator      Base class for a single Binary operator handler for RPN Calculator (takes 2 operands)
     * 
     * This abstract class is the suggested base class for all RPNCalculator binary operators.
     * It implements the stack operations common to all binary operators (pop 2 operands, calculate and push the result)
     * and leaves a new abstract Calculate() method (different signature) for specific Binary operators to implement.
     * 
     * Implement binary operators by providing an implementation of the Calculate and the IsTriggeringInput abstract methods and register the operator in the operators list of the Calculator class.
     * 
     * @author      Ofer Tal
     * @see         Calculator (static constructor), Operator
     **/
    public abstract class BinaryOperator : Operator
    {
        /**
         * Abstract calculate method left for subclasses of BinaryOperator to implement
         * The implementation is expected to perform a calculation on the right and left operands (provided as parameter) and return the result
         * 
         * @param right     the right-hand side operand of the operator
         * @param left      the left-hand side operand of the operator
         * @returns         the result of the operator
         * @throws          Exception (IllegalOperationException recommended) if any error occurred
         **/
        public abstract decimal Calculate(decimal left, decimal right);

        /**
         * this override provides the common implementation of the Operator.Calculate abstract mehtod that is common to all binary operators.
         * It is marked sealed because furhter subclasses that represent binary operators should not need to change this functionality.
         * @param stack     the operand stack of the RPN calculator. operands will be popped off the stack and result will be pushed onto it.
         * @throws          an exception (IllegalOperationException recomended) for any error/invalid input encountered
         **/
        public sealed override void Calculate(Stack<decimal> stack)
        {
            // binary operators require 2 operands. if fewer operands are on the stack, raise an exception.
            if (stack.Count < 2)
            {
                throw new InvalidOperationException("A binary operator requires at least 2 numbers in the stack");
            }

            // pop 2 operands, the first operand (last added) is the right side of the calculation and the 2nd  is the left side of the calculation
            decimal right = stack.Pop();
            decimal left = stack.Pop();

            // send the popped operands to the specfic operand implementation
            decimal result = Calculate(left, right);

            // the result is expected to be pushed onto the stack
            stack.Push(result);
        }
    }
}