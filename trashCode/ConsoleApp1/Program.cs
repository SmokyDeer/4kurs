using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePaths = Directory.GetFiles(@"D:\\институт\\4 КУРС\\4kurs\\ОТИК\\labs\\files\\Тексты\\");
            string savePath = @"D:\\институт\\4 КУРС\\4kurs\\ОТИК\\labs\\files\\Freq\\";
            foreach (string s in filePaths)
            {
                TextData d = new TextData(File.ReadAllText(s));
                File.WriteAllText(savePath + (s.Split('\\'))[s.Split('\\').Length - 1], d.GetResultDefault());
                Console.WriteLine(s);
            }

            Console.ReadKey();

        }


    }

    class TextData
    {
        List<char> sym = new List<char>();
        List<int> symCount = new List<int>();
        List<double> symCountFreq = new List<double>();
        int symCountTotal = 0;
        public TextData(string inputText)
        {
            inputText = inputText.ToLower();
            foreach (char c in inputText.ToCharArray())
            {
                if (sym.Contains(c))
                {
                    for (int i = 0; i < sym.Count; i++)
                    {
                        if (sym[i] == c)
                        {
                            symCount[i]++;
                            symCountTotal++;
                            break;
                        }
                    }
                }
                else
                {
                    sym.Add(c);
                    symCount.Add(1);
                    symCountTotal++;
                }
            }

        }
        public string GetResultDefault()
        {
            string result = "";
            foreach (int i in symCount)
                symCountFreq.Add((double)i / (double)symCountTotal);
            for (int i = 0; i < symCountFreq.Count; i++)
            {
                for (int j = i; j < symCountFreq.Count; j++)
                {
                    if (symCountFreq[i] < symCountFreq[j])
                    {
                        var a = symCountFreq[i];
                        symCountFreq[i] = symCountFreq[j];
                        symCountFreq[j] = a;
                        var b = symCount[i];
                        symCount[i] = symCount[j];
                        symCount[j] = b;
                        var c = sym[i];
                        sym[i] = sym[j];
                        sym[j] = c;
                    }
                }
            }
            for (int i = 0; i < sym.Count; i++)
            {
                result += OctetWorker.CharToHex(sym[i], false, true) + "\t" + symCount[i] + "\t" + symCountFreq[i]  + Environment.NewLine;
            }
            return result;
        }


      
    }
    static class OctetWorker
    {
        public static string CharToHex(char ch, bool IsBinary, bool IsFormat)
        {
            byte[] bytes = BitConverter.GetBytes(ch);
            BitArray bits = new BitArray(bytes);
            Reverse(bits);
            string result = "";

            if (!IsBinary)
            {
                StringBuilder sb = new StringBuilder(bits.Length / 4);
                for (int i = 0; i < bits.Length; i += 4)
                {
                    int v = (bits[i] ? 8 : 0) |
                            (bits[i + 1] ? 4 : 0) |
                            (bits[i + 2] ? 2 : 0) |
                            (bits[i + 3] ? 1 : 0);

                    sb.Append(v.ToString("X1")); // Or "X1"
                }
                result = sb.ToString();

                if (IsFormat)
                    result = result.Substring(result.Length - 2);

            }
            else
            {
                for (int i = 0; i < bits.Count; i++)
                {
                    char c = bits[i] ? '1' : '0';
                    result += c;
                }
            }
            return result;
        }

        public static void Reverse(BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }
    }
}
