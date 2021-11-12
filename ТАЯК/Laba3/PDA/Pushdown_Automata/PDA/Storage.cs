using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PDA
{
    class Storage
    {
        //file
        private HashSet<char> P = new HashSet<char>();// терминальные символы
        private HashSet<char> H = new HashSet<char>();// нетерминальные символы
        char s0 = '0', h0 = '|', empty_symbol = '\0';
        List<Command> commands = new List<Command>();
        List<Link> chain = new List<Link>();

        public Storage(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Не удалось открыть файл для чтения\n");
            
            var lines = File.ReadAllLines(path);

            string tmpStr="";
            int vsize;

            Regex exp = new Regex(@"([A-Z])>([\x20-\x7E]+)");
            foreach (var line in lines)
            {
                tmpStr = line;
                if (tmpStr.Length == 0)
                    continue;
                MatchCollection match = exp.Matches(line);
                //foreach (var item in match)
                //{
                //    Console.WriteLine(item);
                //}

                if (match.Count <= 0 || tmpStr[tmpStr.Length - 1] == '|' || tmpStr[2] == '|')
                {
                    throw new Exception("Не удалось распознать содержимое файла\n");
                }
                else
                {
                    H.Add(match[0].Groups[1].ToString()[0]);//----------------
                    commands.Add(new Command(new Fargs(s0, empty_symbol, match[0].Groups[1].ToString()[0]), new List<Value>()));
                    commands[commands.Count - 1].values.Add(new Value(s0, ""));

                    for (int i = 0; i < match[0].Groups[2].ToString().Length; i++)
                    {
                        if (match[0].Groups[2].ToString()[i] == '|')
                        {
                            if (match[0].Groups[2].ToString()[i - 1] != '|')
                                commands[commands.Count - 1].values.Add(new Value(s0, ""));
                        }
                        else
                        {
                            P.Add(match[0].Groups[2].ToString()[i]);
                            vsize = commands[commands.Count - 1].values.Count;
                            commands[commands.Count - 1].values[vsize - 1] = new Value(commands[commands.Count - 1].values[vsize - 1].s, commands[commands.Count - 1].values[vsize - 1].c + match[0].Groups[2].ToString()[i].ToString());
                        }
                    }
                    for (int i = 0; i < commands[commands.Count - 1].values.Count; i++)
                        commands[commands.Count - 1].values[i].c = Reversestring(commands[commands.Count - 1].values[i].c);
                    
                }
            }
            foreach (var item in H)
                P.Remove(item);

            foreach (var c in P)
                commands.Add(new Command(new Fargs(s0, c, c), new List<Value>() { new Value(s0, "\0") }));
            commands.Add(new Command(new Fargs(s0, empty_symbol, h0), new List<Value>() { new Value(s0, "\0") }));
        }

        public void DisplayInfo()
        {
            StringBuilder resultInfo = new StringBuilder();
            resultInfo.Append("Входной алфавит:\nP = {");
            foreach (var c in P)
                resultInfo.Append(c + ", ");
            resultInfo.Append("\b\b}\n\n");
            resultInfo.Append("Алфавит магазинных символов:\nZ = {");
            foreach (var item in H)
                resultInfo.Append(item + ", ");
            foreach (var item in P)
                resultInfo.Append(item + ", ");
            resultInfo.Append("h0}\n\n");

            resultInfo.Append("Список команд:\n");

            foreach (var c in commands)
            {
                resultInfo.Append("f(s" + c.f.s +", ");
                if (c.f.p==empty_symbol)
                    resultInfo.Append("lambda");
                else
                    resultInfo.Append(c.f.p);
                resultInfo.Append(", ");
                if (c.f.h == h0)
                    resultInfo.Append("h0");
                else
                    resultInfo.Append(c.f.h);
                resultInfo.Append(") = {");
                foreach (var v in c.values)
                {
                    resultInfo.Append("(s" + v.s +", ");
                    if (v.c[0] == empty_symbol)
                        resultInfo.Append("lambda");
                    else
                        resultInfo.Append(v.c);
                    resultInfo.Append("); ");
                }
                resultInfo.Append("\b\b}\n");
            }
            Console.WriteLine(resultInfo.ToString());
        }

        void DisplayChain()
        {
            string res = "\nЦепочка конфигураций: \n";
            foreach (var link in chain)
			    res+= "(s" + link.s + ", " +((link.inp.Length == 0) ? "lambda" : link.inp) +", h0" +link.stack +") |– ";
            res+= "(s0, lambda, lambda)\n";
            Console.Write(res);
        }

        public static string Reversestring(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        bool AddLink()
        {
            int ch_size = chain.Count;
            int mag_size, j, i;
            for (i = 0; i < commands.Count; i++)
            {
                mag_size = chain[ch_size - 1].stack.Length;
                if (chain[chain.Count - 1].inp.Length != 0 && chain[chain.Count - 1].stack.Length != 0 && chain[ch_size - 1].s == commands[i].f.s && (chain[ch_size - 1].inp[0] == commands[i].f.p || empty_symbol == commands[i].f.p) && chain[ch_size - 1].stack[mag_size - 1] == commands[i].f.h)
                {
                    for (j = 0; j < commands[i].values.Count; j++)
                    {
                        if (commands[i].f.p == empty_symbol)
                        {
                            chain.Add(new Link(commands[i].values[j].s, chain[ch_size - 1].inp, chain[ch_size - 1].stack));
                        }
                        else
                        {
                            chain.Add(new Link(commands[i].values[j].s, chain[ch_size - 1].inp, chain[ch_size - 1].stack));
                            chain[ch_size].inp = Reversestring(chain[ch_size].inp);
                            chain[ch_size].inp = chain[ch_size].inp.Remove(chain[ch_size].inp.Length - 1);
                            chain[ch_size].inp = Reversestring(chain[ch_size].inp);
                        }

                        chain[ch_size].stack = chain[ch_size].stack.Remove(chain[ch_size].stack.Length - 1);
                        chain[ch_size].stack += commands[i].values[j].c;

                        if (chain[ch_size].inp.Length < chain[ch_size].stack.Length)
                        {
                            chain.RemoveAt(chain.Count - 1);
                            chain.RemoveAt(chain.Count - 1);
                            return false;
                        }
                        else
                        {
                            if (chain[chain.Count - 1].inp.Length == 0 && chain[chain.Count - 1].stack.Length == 0 || AddLink())
                                return true;
                        }
                    }
                }
            }
            if (i == commands.Count)
            {
                chain.RemoveAt(chain.Count - 1);
                return false;
            }
            return false;
        }

        public bool check_line(string str)
	    {
		    if (commands[0].values.Count == 1)
			    chain.Add(new Link(s0, str, "", false));
		    else
			    chain.Add(new Link(s0, str, "", true));

            chain[0].stack+= commands[0].f.h;
		    bool res = AddLink();
		    if (res)
		    {
                Console.WriteLine("Валидная строка");
			    DisplayChain();
            }
    		else 
            {
	    		Console.WriteLine( "Невалидная строка\n");
		    }
            chain.Clear();
            return res;
	    }
    }
}
