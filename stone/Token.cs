using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone
{
    class Token
    {
        public static readonly Token EOF = new Token(-1);
        public static readonly string EOL = "\\n";
        private int lineNumber;
        protected Token(int line) { lineNumber = line; }
        public virtual int GetLineNumber() { return lineNumber; }
        public virtual bool IsIdentifier() { return false; }
        public virtual bool IsNumber() { return false; }
        public virtual bool IsString() { return false; }
        public virtual int GetNumber() { throw new StoneException("not number token"); }
        public virtual string GetText() { return ""; }
    }
}
