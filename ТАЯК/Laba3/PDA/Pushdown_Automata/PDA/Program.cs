using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PDA
{
    static class Program
    {
        static void Main()
        {
            try
            {

                Storage storage = new Storage("D:\\институт\\4 КУРС\\4kurs\\ТАЯК\\Laba3\\test1.txt");
                storage.DisplayInfo();
                while (true)
                {
                    Console.WriteLine("Введите строку: ");
                    var str = Console.ReadLine();
                    storage.check_line(str);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //string s = "E>mT|!T|T";
            //string s = "bkdvbkj";
            //Regex regex = new Regex(@"([A-Z])>([\x20-\x7E]+)");
            //MatchCollection matches = regex.Matches(s);
            //if (matches.Count > 0)
            //{
            //    //foreach (Match match in matches)
            //    //    foreach (var item in match.Groups)
            //    //        Console.WriteLine(item);
            //    Console.WriteLine(matches[0].ToString()[0]);
            //    Console.WriteLine(matches[0].ToString());
            //}
            //else
            //{
            //    Console.WriteLine("Совпадений не найдено");
            //}

            Console.ReadKey();
        }
    }
}
