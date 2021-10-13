using Lab1.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab1
{
    /**
     * @class Calculator        implementation of a reverse polish notation calculator
     * 
     * This class contains the logic and data structure for:
     * - Maintaining a stack of decimals to hold the operands
     * - Identify commands associated with known operators and dispatch appropriate handler
     * - Any input that is not identified as a command will be treated as numeric input to be pushed onto the stack
     * - If input cannot be interpreted as a valid command or decimal an exception is thrown
     * 
     * To use this class, create an instance of it and call ProcessUserInput with every input provided by user
     * 
     * @author      Ofer Tal
     * @see         https://gist.github.com/nilbus/7029600f8e6446c538f5
     * @see         ProcessUserInput
     */
    public class CalculatorRPN
    {
        // stack will hold the operand stack 
        private Stack<decimal> stack;
        // operators collection (static) contains the list of available Operator classes. 
        private static List<Operator> operators;

        // static constructor for the RPN calculator initializes the list of registered operators once for all Calculator instances
        static CalculatorRPN()
        {
            operators = new List<Operator>();

            operators.Add(new AdditionOperator());
            operators.Add(new SubtractionOperator());
            operators.Add(new MultiplicationOperator());
            operators.Add(new DivisionOperator());
        }

        /**
         * Calculator constructor
         * Initialize a Calculator with the default initial stack size
         **/
        public CalculatorRPN()
        {
            this.stack = new Stack<decimal>();
        }

        /**
         * Calculator constructor (specific initial capacity)
         * @param       initialCapacity: the initial capacity allocated for the stack
         **/
        public CalculatorRPN(int initialCapacity)
        {
            this.stack = new Stack<decimal>(initialCapacity);
        }
        
        /**
         * ProcessUserInput - method for processing a single user input token
         * 
         * For every token, the input will be sent to each operator instance to check if it is the triggering input for that Operator.
         * Triggering inputs will be handed over to the operator instance for it to apply its operation to the stack. The result of the calculation 
         * will be returned in such case by peeking at the stack's head.
         * 
         * Non-Triggering-inputs will be parsed as decimal numeric inputs and pushed onto the stack if parsing succeeds.
         * 
         * Any error during caclulation or parsing will throw an exception that will be handled by the caller.
         * 
         * @param input     input token provided by the user (e.g. "+","-" or a number)
         * @returns         formatted output for display to user as response to the input (may be a result or an error message)
         * @throws          IllegalOperationException (or other Exceptions) in case the input is invalid or caused a calculation error
         **/
        public string ProcessUserInput(string input)
        {
            // check with each registered operator if the iput is recognized as its triggering input
            foreach (Operator op in operators)
            {
                if (op.IsTriggeringInput(input))
                {
                    op.Calculate(stack);
                    return stack.Peek().ToString();
                }
            }
            // if we reached here, the input didn't match any of the operators.
            decimal numericInput;
            if (decimal.TryParse(input, out numericInput))
            {
                stack.Push(numericInput);
                // also return the pushed number as the response (echo) to the user for providing a number
                return input; 
            }

            throw new InvalidOperationException("Invalid input, I don't know what \"" + input + "\" means.");
        }

        public string ToSolve(List<string> operators)
        {
            stack.Clear();
            //operators.Clear();
            string result = "";
            foreach (var item in operators)
            {
                result = ProcessUserInput(item.Replace('.',','));
            }
            return result;
        }
    }
}
