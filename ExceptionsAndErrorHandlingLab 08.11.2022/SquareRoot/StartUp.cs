using System;

namespace SquareRoot
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            try
            {
                double result = SquareRootCalculator.CalculateSquareRoot(number);
                Console.WriteLine(result);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }

    public class SquareRootCalculator
    {
        public static double CalculateSquareRoot(int number)
        {
            if (number<0)
            {
                throw new ArithmeticException("Invalid number.");
            }
            return Math.Sqrt(number);
        }
    }
}
