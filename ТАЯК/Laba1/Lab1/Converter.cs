using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1
{
    public static class Converter
    {
        public static bool Сonvert(ref string infix, out string postfix)
        {

            int prio = 0;
            postfix = "";
            Stack<Char> s1 = new Stack<char>();
            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {

                    if (s1.Count <= 0)
                        s1.Push(ch);
                    else
                    {
                        if (s1.Peek() == '*' || s1.Peek() == '/')
                            prio = 1;
                        else
                            prio = 0;
                        if (prio == 1)
                        {
                            if (ch == '+' || ch == '-')
                            {
                                postfix += s1.Pop();
                                i--;
                            }
                            else
                            {
                                postfix += s1.Pop();
                                i--;
                            }
                        }
                        else
                        {
                            if (ch == '+' || ch == '-')
                            {
                                postfix += s1.Pop();
                                s1.Push(ch);

                            }
                            else
                                s1.Push(ch);
                        }
                    }
                }
                else
                {
                    postfix += ch;
                }
            }
            int len = s1.Count;
            for (int j = 0; j < len; j++)
                postfix += s1.Pop();
            return true;
        }

        public static string InfixToPostfix(string exp)
        {
            // initializing empty String for result
            String result = String.Empty;
            exp = String.Concat(exp.Where(c => !Char.IsWhiteSpace(c)));

            // initializing empty stack
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                if (!Char.IsLetterOrDigit(c) && c!='.' && c != ',')
                {
                    //result += " ";
                    AddSpace(ref result);
                }

                // If the scanned character is an operand, add it to output.
                if (Char.IsLetterOrDigit(c) || c == '.' || c == ',')
                    result += c;

                // If the scanned character is an '(', push it to the stack.
                else if (c == '(')
                    stack.Push(c);

                

                //  If the scanned character is an ')', pop and output from the stack 
                // until an '(' is encountered.
                else if (c == ')')
                {
                    while (stack.Count != 0 && stack.Peek() != '(')
                        result += stack.Pop();

                    if (stack.Count != 0 && stack.Peek() != '(')
                        return "Invalid Expression"; // invalid expression                
                    else
                        stack.Pop();
                }
                else // an operator is encountered
                {
                    while (stack.Count != 0 && Prec(c) <= Prec(stack.Peek()))
                    {
                        result += stack.Pop();
                        AddSpace(ref result);
                    }
                        
                    stack.Push(c);
                }

              
            }
        
            // pop all the operators from the stack
            while (stack.Count != 0)
            {
                //result += " ";
                AddSpace(ref result);
                result += stack.Pop();
            }
                

            return result;
        }

        public static int Prec(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }
        private static void AddSpace(ref string value)
        {
            if(value.Length > 0)
            {
                if(value[value.Length-1] != ' ')
                {
                    value += " ";
                }
            }
        }
    }

    
}
