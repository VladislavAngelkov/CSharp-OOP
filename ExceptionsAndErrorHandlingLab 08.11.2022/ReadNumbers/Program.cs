using System;

namespace ReadNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            int start = 1;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int currentNumber = ReadNumbers(start, 100);

                    array[i] = currentNumber;
                    start = currentNumber;

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }

            }

            Console.WriteLine(string.Join(", ", array));
        }

        public static int ReadNumbers(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }
            return number;
        }
    }
}
