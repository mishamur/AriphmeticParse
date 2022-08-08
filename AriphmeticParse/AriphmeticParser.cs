using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AriphmeticParse.Utils;

namespace AriphmeticParse
{
    public class AriphmeticParser
    {
        public static List<Lexem> Parse(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                List<Lexem> result = new List<Lexem>();
                //проход по стрке и выделения лексем
                int i = 0;
                while(i < input.Length)
                {
                    char ch = input[i];
                    switch (ch)
                    {
                        case '+':
                            result.Add(new Lexem(LexemType.OpPlus, ch));
                            break;
                        case '-':
                            result.Add(new Lexem(LexemType.OpMinus, ch));
                            break;
                        case '*':
                            result.Add(new Lexem(LexemType.OpMult, ch));
                            break;
                        case '/':
                            result.Add(new Lexem(LexemType.OpDiv, ch));
                            break;
                        case '(':
                        result.Add(new Lexem(LexemType.OpenParenthesis, ch));
                            break;
                        case ')':
                            result.Add(new Lexem(LexemType.CloseParenthesis, ch));
                            break;
                        default: 
                            if(ch >= '0' && ch <= '9')
                            {
                                StringBuilder stringNumbers = new StringBuilder();

                                do
                                {
                                    stringNumbers.Append(ch.ToString());
                                    i++;
                                    if (i < input.Length)
                                    {
                                        ch = input[i];
                                    }
                                    
                                    
                                } while (ch >= '0' && ch <= '9' && i < input.Length);
                                result.Add(new Lexem(LexemType.Number, stringNumbers.ToString()));
                                i--;
                            }
                            else if ( ch != ' ')
                            {
                                throw new ArgumentException();
                            }
                            break;
                    }
                    i++;
                }
                result.Add(new Lexem(LexemType.EndStr, ""));
                return result;
            }
            else
            {
                throw new ArgumentException();
            }

            
        }

    }
}
