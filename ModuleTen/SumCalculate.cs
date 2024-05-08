using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModuleTen.Program;

namespace ModuleTen
{
    public interface ISumCalculate
    {
       public void Sum(double a, double b);
    }

    public class SumCalculate : ISumCalculate
    {
        private readonly ILogger _logger;

        public SumCalculate(ILogger logger)
        {
            _logger = logger;
        }

        public void Sum(double a, double b)
        {
            double c = a + b;
            string sum = c.ToString();
            Console.WriteLine(sum);
        }

        /// метод для проверки ввода числа
        public static bool IsDigit(string value)
        {
            double num;
            bool isDigit = double.TryParse(value, out num);
            return isDigit;
        }
    }
}
