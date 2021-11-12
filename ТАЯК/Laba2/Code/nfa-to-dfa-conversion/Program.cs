using nfa_to_dfa_conversion.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace nfa_to_dfa_conversion
{
    public static class Program
    {
        public static Stopwatch Timer = new Stopwatch();
        public static List<string> BenchmarkResults = new List<string>();
        private static string _filePath1 = "D:\\институт\\4 КУРС\\4kurs\\ТАЯК\\Laba2\\var1.txt";
        private static string _filePath2 = "D:\\институт\\4 КУРС\\4kurs\\ТАЯК\\Laba2\\var2.txt";
        private static string _filePath3 = "D:\\институт\\4 КУРС\\4kurs\\ТАЯК\\Laba2\\var3_nd.txt";
        private static void Main(string[] args)
        {
            
            

            //
            //NFAFunction(inputString);

            //TWDFAFunction(inputString);

            //

            MyFunction1();
            MyFunction2();
            MyFunction3();
        }

    

     

        #region MyBuilders
        
        private static DecodedFile ReadFile(string path)
        {
            //string text = System.IO.File.ReadAllText(path);
            string[] lines = System.IO.File.ReadAllLines(path);
            DecodedFile decodedFile = new DecodedFile(lines);
            Console.WriteLine(decodedFile.ToString());
            return decodedFile;
        }

        private static FiniteAutomata BuildAutomataFromFile(string path, FiniteAutomataType finiteAutomataType)
        {
            DecodedFile decodedFile = ReadFile(path);
            FiniteAutomata finiteAutomata = new FiniteAutomata(finiteAutomataType, decodedFile.GetAlphabetList());

            List<string> states = decodedFile.GetStatesList();
            List<(char, string, string)> transitions = decodedFile.Transitions;


            //set states
            for (int i = 0; i < states.Count; i++)
            {
                if(i==0)
                    finiteAutomata.AddState(states[i], isInitialState:true);
                else if (i == states.Count-1)
                    finiteAutomata.AddState(states[i], isFinalState:true);
                else
                    finiteAutomata.AddState(states[i]);
            }

            // set transitions
            for (int i = 0; i < transitions.Count; i++)
            {
                _ = finiteAutomata.AddTransition(transitions[i].Item1, transitions[i].Item2, transitions[i].Item3);
            }

            return finiteAutomata;
        }
        #endregion

        #region MyFunctions
        private static void MyFunction1()
        {
            string inputStringValid = "aa+cd*ee=357";
            string inputStringInvalid = "aacd";
            ConsoleOperations.WriteTitle("Input String");
            Console.WriteLine($">> {inputStringValid}");
            Console.WriteLine($">> {inputStringInvalid}");

            FiniteAutomata automata = BuildAutomataFromFile(_filePath1, FiniteAutomataType.NFA);
            ConsoleOperations.WriteBMarkReset("Creation");

            ConsoleOperations.WriteTitle("Info");
            ConsoleOperations.WriteAutomataInfo(automata);

            ConsoleOperations.WriteTitle("Trace");
            bool result = automata.Run(inputStringValid);
            ConsoleOperations.WriteBMarkReset("Run");

            ConsoleOperations.WriteTitle("Trace");
            result = automata.Run(inputStringInvalid);
            ConsoleOperations.WriteBMarkReset("Run");


            //FiniteAutomataConverter dfaConverter = new FiniteAutomataConverter();
            //FiniteAutomata DFAVersion = dfaConverter.ConvertNFAToDFA(automata);
            //ConsoleOperations.WriteBMarkReset("Automata Conversion");

            //Console.WriteLine("\n>>>NFA is converted to DFA<<<\n");
            //ConsoleOperations.WriteTitle("DFA Info");
            // ConsoleOperations.WriteAutomataInfo(DFAVersion);

            //ConsoleOperations.WriteTitle("DFA Trace");
            //bool resultDFA = DFAVersion.Run(inputString);
            //ConsoleOperations.WriteBMarkReset("DFA Run");
            //Timer.Stop();

            //ConsoleOperations.WriteTitle("Automata Results");
            //Console.WriteLine("NFA Response: Input is " + (result ? "Accepted" : "Rejected"));
            //Console.WriteLine("DFA Response: Input is " + (resultDFA ? "Accepted" : "Rejected"));

            //ConsoleOperations.WriteTitle("Benchmark Results");
            //BenchmarkResults.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("------------------------------------------");
        }

        private static void MyFunction2()
        {

            string inputStringValid = "/+g*";
            string inputStringInvalid = "aacd";
            ConsoleOperations.WriteTitle("Input String");
            Console.WriteLine($">> {inputStringValid}");
            Console.WriteLine($">> {inputStringInvalid}");

            FiniteAutomata automata = BuildAutomataFromFile(_filePath2, FiniteAutomataType.NFA);
            ConsoleOperations.WriteBMarkReset("Creation");

            ConsoleOperations.WriteTitle("Info");
            ConsoleOperations.WriteAutomataInfo(automata);

            ConsoleOperations.WriteTitle("Trace");
            bool result = automata.Run(inputStringValid);
            ConsoleOperations.WriteBMarkReset("Run");

            ConsoleOperations.WriteTitle("Trace");
            result = automata.Run(inputStringInvalid);
            ConsoleOperations.WriteBMarkReset("Run");



            Console.WriteLine("------------------------------------------");
        }

        private static void MyFunction3()
        {
            string inputStringValid = "aebf";
            string inputStringInvalid = "aacd";
            ConsoleOperations.WriteTitle("Input String");
            Console.WriteLine($">> {inputStringValid}");
            Console.WriteLine($">> {inputStringInvalid}");

            FiniteAutomata automata = BuildAutomataFromFile(_filePath3, FiniteAutomataType.NFA);
            ConsoleOperations.WriteBMarkReset("Creation");

            ConsoleOperations.WriteTitle("Info");
            ConsoleOperations.WriteAutomataInfo(automata);

            ConsoleOperations.WriteTitle("Trace");
            bool result = automata.Run(inputStringValid);
            ConsoleOperations.WriteBMarkReset("Run");

            ConsoleOperations.WriteTitle("Trace");
            result = automata.Run(inputStringInvalid);
            ConsoleOperations.WriteBMarkReset("Run");

            FiniteAutomataConverter dfaConverter = new FiniteAutomataConverter();
            FiniteAutomata DFAVersion = dfaConverter.ConvertNFAToDFA(automata);
            ConsoleOperations.WriteBMarkReset("Automata Conversion");


            Console.WriteLine("\n>>>NFA is converted to DFA<<<\n");
            ConsoleOperations.WriteTitle("DFA Info");
            ConsoleOperations.WriteAutomataInfo(DFAVersion);

            ConsoleOperations.WriteTitle("DFA Trace");
            bool resultDFA = DFAVersion.Run(inputStringValid);
            ConsoleOperations.WriteBMarkReset("DFA Run");

            Console.WriteLine("----------------------------------------------------------------------");
        }
        #endregion

    }
}