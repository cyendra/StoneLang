using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    class ASTLeaf : ASTree
    {
        private static List<ASTree> empty = new List<ASTree>();
        protected Token token;
        public ASTLeaf(Token t)
        {
            token = t;
        }
        public override ASTree Child(int i)
        {
            throw new NotImplementedException();
        }
        public override int NumChildren()
        {
            return 0;
        }
        public override IEnumerator<ASTree> Children()
        {
            return empty.GetEnumerator();
        }
        public override string ToString()
        {
            return token.GetText();
        }
        public override string Location()
        {
            return "at line " + token.GetLineNumber();
        }
        public Token Token()
        {
            return token;
        }
    }
}
