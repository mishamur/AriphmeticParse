using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AriphmeticParse.Utils;
using AriphmeticParse.UserExceptions;

/* Весьма интересные правило парсинга
 *  expr : PLUSMIN* EndStr ;
 *  plusminus: MULTDIV ( ( '+' | '-' ) MULTDIV )* ;
 *  multdiv : FACTOR ( ( '*' | '/' ) FACTOR )* ;
 *  factor : number | '(' EXPR ')' ;
 */


namespace AriphmeticParse
{
    public class CalcLexemes
    {
        List<Lexem> lexemes;
        public int Position { get; private set; }    

        public CalcLexemes(List<Lexem> lexemes)
        {
            this.lexemes = lexemes;
            Position = 0;
        }
        /// <summary>
        /// Производит расчёт по заданному массиву лексем
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CalcLexemesException"></exception>
        public double Calc()
        {
            Position = 0;
            double result = Expr();
            return result;
            
        }

        private Lexem NextLexem()
        {
            return lexemes[Position++];
        }

        private void BackLexem()
        {
            Position--;
        }

        //входной метод обработки 
        private double Expr()
        {
            Lexem lexem = NextLexem();
            if (lexem.LexemType == LexemType.EndStr)
            {
                return 0;
            }
            else
            {
                BackLexem();
                return PlusMin();
            }

        }

        private double PlusMin()
        {
            double value = MultDiv();
            while (true)
            {
                Lexem lexem = NextLexem();
                switch (lexem.LexemType)
                {
                    case LexemType.OpPlus:
                        value += MultDiv();
                        break;
                    case LexemType.OpMinus:
                        value -= MultDiv();
                        break;
                    case LexemType.CloseParenthesis:
                    case LexemType.EndStr:
                        BackLexem();
                        return value;
                    
                    default:
                        throw new CalcLexemesException($"Непредвиденный символ: {lexem.Value} в позиции {this.Position}");
                }
            }
        }

        private double MultDiv()
        {
            double value = Factor();
            while (true)
            {
                Lexem lexem = NextLexem();
                switch (lexem.LexemType)
                {
                    case LexemType.OpMult:
                        value *= Factor();
                        break;
                    case LexemType.OpDiv: 
                        value /= Factor();
                        break;
                    case LexemType.EndStr:
                    case LexemType.OpPlus:
                    case LexemType.OpMinus:
                    case LexemType.CloseParenthesis:
                        BackLexem();
                        return value;
                    default:
                        throw new CalcLexemesException($"Непредвиденный символ: {lexem.Value} в позиции {this.Position}");
                }
            }
        }

        private double Factor()
        {
            Lexem lexem = NextLexem();
            switch(lexem.LexemType)
            {
                case LexemType.Number:
                    return double.Parse(lexem.Value);
                case LexemType.OpenParenthesis:
                    double value = PlusMin(); 
                    lexem = NextLexem();
                    if (lexem.LexemType != LexemType.CloseParenthesis)
                        throw new CalcLexemesException($"Непредвиденный символ: {lexem.Value} в позиции {this.Position}");
                    return value;

                default:
                    throw new CalcLexemesException($"Непредвиденный символ: {lexem.Value} в позиции {this.Position}");

            }
        }
    }
}
