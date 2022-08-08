using AriphmeticParse;
using AriphmeticParse.UserExceptions;
using AriphmeticParse.Utils;
using AriphmeticParse.Log;


delegate void DelgateLog(string message);

public static class Program
{
    static event DelgateLog ExceptionLogEvent;
    public static void Main(string[] args)
    {
        Logger consoleLogger = new ConsoleLogger();
        ExceptionLogEvent += consoleLogger.Log;
        
        List<Lexem> ariphmeticExpression = null;
        try
        {
            ariphmeticExpression = AriphmeticParser.Parse("5 / 2 * (1 + 2)");
        }
        catch(ArgumentException ex)
        {
            //логгер
            ExceptionLogEvent?.Invoke(ex.Message);
        }
        catch(Exception ex)
        {
            //....какая-нибудь обработка совсем непредвиденного исключения и проброс её дальше
            ExceptionLogEvent?.Invoke(ex.Message);
            throw;
        }


        CalcLexemes calcLexemes = null;
        double result = 0;
        try
        {
            if(ariphmeticExpression != null)
            {
                calcLexemes = new CalcLexemes(ariphmeticExpression);
                result = calcLexemes.Calc();
            }
                
        }
        catch(CalcLexemesException ex)
        {
            //логгер
            ExceptionLogEvent?.Invoke(ex.Message);
        }
        catch(Exception ex)
        {
            ExceptionLogEvent?.Invoke(ex.Message);
            throw;
        };

        


        Console.WriteLine(result);
    }
}
