using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    class NumberLiteral : ASTLeaf
    {
        public NumberLiteral(Token t) : base(t) { }
        public int Value()
        {
            return token.GetNumber();
        }
    }
}
