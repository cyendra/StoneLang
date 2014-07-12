using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    class Name : ASTLeaf
    {
        public Name(Token t) : base(t) { }
        public string GetName()
        {
            return token.GetText();
        }
    }
}
