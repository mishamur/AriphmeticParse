using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriphmeticParse.Utils
{
    public class Lexem
    {
        public string Value { get; private set; }
        public LexemType LexemType { get; private set; }

        public Lexem(LexemType lexemType, string value)
        {
            this.LexemType = lexemType;
            this.Value = value;
        }


        public Lexem(LexemType lexemType, char value)
        {
            this.LexemType = lexemType;
            this.Value = value.ToString();
        }
    }
}
