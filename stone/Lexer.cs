using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace stone
{
    class Lexer
    {
        private StringReader reader;
        private static const int EMPTY = -1;
        private int lastChar = EMPTY;

        public Lexer(StringReader r) { reader = r; }
        
        private int GetChar()
        {
            if (lastChar == EMPTY)
            {
                return reader.Read();
            }
            else
            {
                int c = lastChar;
                lastChar = EMPTY;
                return c;
            }
        }
        private void UnGetChar(int c) { lastChar = c; }
        
        public string read()
        {
            StringBuilder sb = new StringBuilder();
            int c;
            do
            {
                c = GetChar();
            } while (IsSpace(c));
            if (c < 0) return null;
            else if (IsDigit(c))
            {
                do
                {
                    sb.Append((char)c);
                    c = GetChar();
                } while (IsDigit(c));
            }
            else if (IsLetter(c))
            {
                do
                {
                    sb.Append((char)c);
                    c = GetChar();
                } while (IsLetter(c) || IsDigit(c));
            }
            else if (c == '=')
            {
                c = GetChar();
                if (c == '=') 
                {
                    return "==";
                }
                else
                {
                    UnGetChar(c);
                    return "=";
                }
            }
            else
            {
                throw new IOException();
            }
            if (c >= 0) UnGetChar(c);
            return sb.ToString();
        }

        private static bool IsLetter(int c) { return c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z'; }
        private static bool IsDigit(int c) { return c >= '0' && c <= '9'; }
        private static bool IsSpace(int c) { return c >= 0 && c <= ' '; }
    }
}
