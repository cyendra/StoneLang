using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    class BinaryExpr : ASTList
    {
        public BinaryExpr(List<ASTree> c) : base(c) { }
        public ASTree Left() { return Child(0); }
        public string Operator()
        {
            return ((ASTLeaf)Child(1)).Token().GetText();
        }
        public ASTree Right()
        {
            return Child(2);
        }
    }
}
