using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stone;
namespace Parser
{
    abstract class Element
    {
        public abstract void Parse(Lexer lexer, List<ASTree> res);
        public abstract bool Match(Lexer lexer);
    }

    class Tree : Element
    {
        public Parser parser;
        public Tree(Parser p)
        {
            parser = p;
        }
        public override void Parse(Lexer lexer, List<ASTree> res)
        {
            res.Add(parser.Parse(lexer));
        }
        public override bool Match(Lexer lexer)
        {
            return parser.Match(lexer);
        }
    }

    class OrTree : Element
    {

    }

    class Repeat : Element
    {

    }

    class AToken : Element
    {

    }

    class IdToken : AToken
    {

    }

    class NumToken : AToken
    {

    }

    class StrToken : AToken
    {

    }

    class Leaf : Element
    {

    }

    class Skip : Leaf
    {

    }

    class Precedence
    {

    }

    class Operators : Dictionary<string, Precedence>
    {

    }

    class Expr : Element
    {

    }

    abstract class Factory
    {
        public abstract ASTree make0(Object arg);
        public ASTree make(Object arg)
        {
            try
            {
                return make0(arg);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
    }
    


    class Parser
    {
        public static readonly string factoryName = "create";


    }
}
