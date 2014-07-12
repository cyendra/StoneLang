using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace stone
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            Lexer lex = new Lexer(new StringReader(codeBox.Text));
            Token tok;
            do
            {
                tok = lex.Read();
                Console.WriteLine("" + tok.GetLineNumber() + " " + tok.GetText());
            } while (tok != Token.EOF);
        }
    }
}
