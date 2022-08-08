using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriphmeticParse.Utils
{
    public enum LexemType
    {
        Number,
        OpPlus,
        OpMinus,    
        OpMult,
        OpDiv,
        OpenParenthesis,
        CloseParenthesis,
        EndStr
    }
}
