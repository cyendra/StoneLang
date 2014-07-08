using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    class StoneException : Exception
    {
        public StoneException(string m) : base(m) { }
        public StoneException(string m, ASTree t) : base(m + " " + t.location()) { }
    }
}
