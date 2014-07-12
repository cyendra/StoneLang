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
        private List<Token> queue = new List<Token>();

        private int line;

        private static readonly int EMPTY = -1;
        private int lastChar = EMPTY;

        public Lexer(StringReader r) { 
            reader = r;
            line = 1;
        }

        public Token Read()
        {
            if (FillQueue(0))
            {
                Token tok = queue[0];
                queue.RemoveAt(0);
                return tok;
            }
            else return Token.EOF;
        }

        public Token Peek(int i)
        {
            if (FillQueue(i)) return queue[i];
            else return Token.EOF;
        }

        private bool FillQueue(int i)
        {
            while (i >= queue.Count)
            {
                Token tok = ReadToken();
                if (tok == null) return false;
                queue.Add(tok);
            }
            return true;
        }
        
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
        private bool ReadCh(int c)
        {
            int pk = GetChar();
            if (pk != c)
            {
                UnGetChar(pk);
                return false;
            }
            return true;
        }

        private Token ReadToken()
        {
            StringBuilder sb = new StringBuilder();
            int c;
            do
            {
                c = GetChar();
                if (c == (int)'\n')
                {
                    return new IdToken(line++, Token.EOL);
                }
            } while (IsSpace(c));
            if (c < 0) return null;
            if (c == '\"')
            {
                c = GetChar();
                while (c != '\"')
                {
                    sb.Append(c);
                    c = GetChar();
                }
                return new StrToken(line++, sb.ToString());
            }
            switch (c)
            {
                case '=':
                    if (ReadCh('=')) return new IdToken(line, "==");
                    else return new IdToken(line, "=");
                case '>':
                    if (ReadCh('=')) return new IdToken(line, ">=");
                    else return new IdToken(line, ">");
                case '<':
                    if (ReadCh('=')) return new IdToken(line, "<=");
                    else return new IdToken(line, "<");
            }

            if (IsDigit(c))
            {
                do
                {
                    sb.Append((char)c);
                    c = GetChar();
                } while (IsDigit(c));
                UnGetChar(c);
                return new NumToken(line, int.Parse(sb.ToString()));
            }
            
            if (IsLetter(c))
            {
                do
                {
                    sb.Append((char)c);
                    c = GetChar();
                } while (IsLetter(c) || IsDigit(c));
                UnGetChar(c);
                return new IdToken(line, sb.ToString());
            }
            return new IdToken(line, ""+(char)c);
        }

        private static bool IsLetter(int c) { return c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z'; }
        private static bool IsDigit(int c) { return c >= '0' && c <= '9'; }
        private static bool IsSpace(int c) { return c >= 0 && c <= ' '; }
    }

}
