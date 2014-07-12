using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    abstract class ASTree : IEnumerable<ASTree>
    {
        public abstract ASTree Child(int i);
        public abstract int NumChildren();
        public abstract string Location();
        public abstract IEnumerator<ASTree> Children();
      
        public IEnumerator<ASTree> GetEnumerator()
        {
            return Children();
        }
    }
}
