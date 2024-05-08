using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ModuleTen
{
    public class Program
    {
        static ILogger logger { get; set; }
        static void Main(string[] args)
        {
            logger = new Logger();
            ISumCalculate sumCalculate = new SumCalculate(logger);

            double a, b;

            try
            {
                Console.WriteLine("Введите первое слагаемое:");
                string value1 = Console.ReadLine();
                bool isDigit1 = SumCalculate.IsDigit(value1);

                Console.WriteLine("Введите второе слагаемое:");
                string value2 = Console.ReadLine();
                bool isDigit2 = SumCalculate.IsDigit(value2);

                /// проверяем, являются ли два введённых значения числами
                if (isDigit1 == true && isDigit2 == true)
                {
                    a = double.Parse(value1);
                    b = double.Parse(value2);
                    logger.Event("Результат вычисления:");
                    sumCalculate.Sum(a, b);
                }
                else
                {
                    logger.Error("Не удалось получить результат!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            Console.ReadKey();
        }

        public interface ILogger
        {
            void Event(string message);
            void Error(string message);
        }

        public class Logger : ILogger
        {
            public void Error(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(message);
            }

            public void Event(string message)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(message);
            }
        }
    }
}
