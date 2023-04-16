using System;

namespace EnterNumbers
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            ReadNumbers(0, 100);
        }

        public static void ReadNumbers(int start, int end)
        {
            int[] array = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                try
                {
                    if (currentNumber <= start || currentNumber >= end)
                    {
                        throw new ArgumentException("Your number is not in range (1 - 100)");
                    }

                    if (i > 0 && currentNumber <= array[i - 1])
                    {
                        throw new ArgumentException("Invalid number!");
                    }

                    array[i] = currentNumber;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}