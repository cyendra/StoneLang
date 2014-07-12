using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    abstract class ASTree
    {
        public abstract ASTree child(int i);
        public abstract int NumChildren();
        public abstract string location();
    }
}
