using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDA
{
    class Command
    {
        public Fargs f;
        public List<Value> values;
        
        public Command(Fargs f, List<Value> v)
        {
            this.f = f;
            values = v;
        }
    }
}
