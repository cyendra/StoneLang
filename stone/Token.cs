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
    class NumToken : Token
    {
        private int value;
        public NumToken(int line, int v) : base(line) { value = v; }
        public override bool IsNumber() { return true; }
        public override string GetText() { return ""+value; }
        public override int GetNumber() { return value; }
    }
    class IdToken : Token
    {
        private string text;
        public IdToken(int line, string id) : base(line) { text = id; }
        public override bool IsIdentifier() { return true; }
        public override string GetText() { return text; }
    }
    class StrToken : Token
    {
        private string literal;
        public StrToken(int line, string str) : base(line)
        {
            literal = str;
        }
        public override bool IsString() { return true; }
        public override string GetText() { return literal; }
    }
}
