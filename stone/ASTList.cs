using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    class ASTList : ASTree
    {
        protected List<ASTree> children;
        public ASTList (List<ASTree> list)
        {
            children = list;
        }
        public override ASTree Child(int i)
        {
            return children[i];
        }
        public override int NumChildren()
        {
            return children.Count;
        }
        public override IEnumerator<ASTree> Children()
        {
            return children.GetEnumerator();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('(');
            string sep = "";
            foreach (ASTree t in children)
            {
                builder.Append(sep);
                sep = " ";
                builder.Append(t.ToString());
            }
            return builder.Append(')').ToString();
        }
        public override string Location()
        {
            foreach (ASTree t in children)
            {
                string s = t.Location();
                if (s != null) return s;
            }
            return null;
        }
    }
}
