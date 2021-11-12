using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDA
{
    class Value
    {
        public char s;     // состояние
        public string c;   // заносимая цепочка

        public Value(char s, string c)
        {
            this.s = s;
            this.c = c;
        }
    }
}
