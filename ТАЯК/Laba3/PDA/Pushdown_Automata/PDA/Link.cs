using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDA
{
    class Link
    {
        public char s; // состояние
        public string inp; // оставшаяся часть входной ленты
        public string stack; // состояние магазина на данный момент
        public int index; // индекс возможного значения функции
        public bool term; // можно ли менять выбор ветви на данном ходе

        public Link(char s, string p, string h, bool t)
        {
            this.s = s;
            inp = p;
            stack = h;
            index = (-1);
            term = t;
        }

        public Link(char s, string p, string h) 
        {
            this.s = s;
            inp = p;
            stack = h;
            index = (-1);
            term = false;
        }
    }
}
