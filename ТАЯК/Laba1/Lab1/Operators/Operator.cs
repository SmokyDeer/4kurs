using System;
using System.Collections.Generic;


namespace Lab1.Operators
{
    /**
     * @class Operator      Base class for a single operator handler for RPN Calculator
     * 
     * This abstract class is the required base class for all RPNCalculator operrators.
     * Implement operators by providing an implementation of the Calculate and the IsTriggeringInput abstract methods and register the operator in the operators list of the Calculator class.
     * 
     * @author      Ofer Tal
     * @see         Calculator (static constructor)
     **/
    public abstract class Operator
    {
        /**
         * Calculate - perform operator calculation on operands popped from the stack and push the result to the stack
         **/
        public abstract void Calculate(Stack<decimal> stack);

        /**
         * IsTriggeringInput - check if an input token is the triggering input for this operator
         * @param input     the user input token
         * @returns         true iff the input token is the triggering string for this operation
         **/
        public abstract bool IsTriggeringInput(string input);
    }
}
