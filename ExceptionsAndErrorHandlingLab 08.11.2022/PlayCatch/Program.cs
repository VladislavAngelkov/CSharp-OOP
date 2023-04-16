using System;
using System.Linq;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int exceptions = 0;

            string[] cmdArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                string command = cmdArg[0];

                try
                {
                    if (command == "Replace")
                    {
                        int index = int.Parse(cmdArg[1]);
                        int element = int.Parse(cmdArg[2]);

                        numbers[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int startIndex = int.Parse(cmdArg[1]);
                        int endIndex = int.Parse(cmdArg[2]);

                        if (startIndex<0||startIndex>=numbers.Length || endIndex<0||endIndex>=numbers.Length || startIndex>endIndex)
                        {
                            throw new IndexOutOfRangeException();
                        }

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            if (i != endIndex)
                            {
                                Console.Write($"{numbers[i]}, ");
                            }
                            else
                            {
                                Console.WriteLine(numbers[i]);
                            }
                        }

                    }
                    else if (command == "Show")
                    {
                        int index = int.Parse(cmdArg[1]);
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptions++;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptions++;
                }

                if (exceptions == 3)
                {
                    Console.WriteLine(string.Join(", ", numbers));
                    return;
                }


                cmdArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
