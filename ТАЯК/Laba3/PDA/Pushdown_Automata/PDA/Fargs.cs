using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDA
{
     class Fargs
    {
        public char s; // состояние
        public char p; // символ со входной ленты
        public char h; // магазинный символ

        public Fargs(char s, char p, char h) 
        {
            this.s = s;
            this.p = p;
            this.h = h;
        }
    }
}
