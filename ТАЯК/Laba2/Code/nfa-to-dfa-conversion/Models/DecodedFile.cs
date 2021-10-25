using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace nfa_to_dfa_conversion.Models
{
    class DecodedFile
    {
        public HashSet<char>  Alphabet { get; private set; }
        public HashSet<string> States { get; private set; }
        public List<(char, string, string)> Transitions { get; private set; }
        public DecodedFile(string[] lines)
        {
            Alphabet = new HashSet<char>();
            States = new HashSet<string>();
            Transitions = new List<(char, string, string)>();
            ToDecode(lines);
        }
        public void ToDecode(string[] lines)
        {
            DecodeAll(lines);
        }

        private  void DecodeAll(string[] fileText)
        {
            

            foreach (string line in fileText)
            {
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                var a = SplitLine(line);
                Alphabet.Add(a.Item1);

                Transitions.Add(a);

                States.Add(a.Item2);
                States.Add(a.Item3);
            }
            
        }

        private static HashSet<char> GetAlphabet(string[] fileText)
        {
            HashSet<char> alphabet = new HashSet<char>();

            foreach (string line in fileText)
            {
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                var a = SplitLine(line);
                //q0,* <- target
                alphabet.Add(a.Item1);
            }
            return alphabet;
        }

        private static List<(char, string, string)> GetTransitions(string[] fileText)
        {
            List<(char, string, string)> transitions = new List<(char, string, string)>();

            foreach (var line in fileText)
            {
                var a = SplitLine(line);
                transitions.Add(a);
            }

            return transitions;
        }

        private static HashSet<string> GetStates(string[] fileText)
        {
            HashSet<string> states = new HashSet<string>();

            foreach (var line in fileText)
            {
                var a = SplitLine(line);
                states.Add(a.Item2);
                states.Add(a.Item3);
            }
            return states;
        }

        public List<char> GetAlphabetList()
        {
            return Alphabet.ToList();
        }

        public List<string> GetStatesList()
        {
            return States.ToList();
        }

        public override string ToString()
        {
            string res = "";
            res += "____________________\nAlphabet: ";
            foreach (var item in Alphabet)
            {
                res += item + ", ";
            }

            res += "\n____________________\nStates: ";
            foreach (var item in States)
            {
                res += item + ", ";
            }
            return res;

            res += "\n____________________\nTranstion: ";
            foreach (var item in Transitions)
            {
                res += "("+item.Item1 + ", "+ item.Item2+", "+item.Item3+")";
            }
            return res;
        }

        private static (char, string, string) SplitLine(string line)
        {
            (char, string, string) result;

            var firstArg = line.IndexOf(',');
            result.Item2 = line.Substring(0, firstArg);

            var secondArg = line.LastIndexOf('=');
            result.Item1 = line.Substring(firstArg+1, secondArg - firstArg-1)[0];

            result.Item3 = line.Substring(secondArg+1, line.Length - secondArg-1);

            return result;
        }
    }
}
