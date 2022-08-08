using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriphmeticParse.UserExceptions
{
    internal class CalcLexemesException : ArgumentException
    {
        public CalcLexemesException(string message) : base(message)
        {

        }

    }
}
