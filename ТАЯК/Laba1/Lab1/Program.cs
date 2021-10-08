using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while(true)
            {
                Console.WriteLine("Введите выражение или \"exit\" для выхода:\n");
                input = Console.ReadLine();
                if (input == "exit")
                    break;

                string convertedString = Converter.InfixToPostfix(input);
                //Converter.Сonvert(ref input, out convertedString);
                Console.WriteLine(convertedString);
                
                
                //if(Converter.Сonvert(ref input, out convertedString))
                //{
                //    //string[] operators
                //    Console.WriteLine(convertedString);
                //    Calculator calc = new Calculator();
                //    foreach(var a in convertedString)
                //    {
                //        calc.ProcessUserInput(a.ToString());
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Неверное выражение!");
                //    continue;
                //}



            }
        }
    }
}
