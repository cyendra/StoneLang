using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace stone
{
    class ParseException : Exception
    {
        public ParseException(string msg) : base(msg) { }
        public ParseException(Token t) : this("", t) { }
        public ParseException(string msg, Token t) : base("syntax error around " + location(t) + ". " + msg) { }
        private static string location(Token t)
        {
            if (t == Token.EOF) return "the last line";
            else return "\"" + t.GetText() + "\" at line " + t.GetLineNumber();
        }
    }
}
