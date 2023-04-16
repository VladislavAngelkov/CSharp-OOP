using System;
using System.Collections.Generic;
using System.Data;

namespace MoneyTransaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] accountsInfo = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, double> accounts = new Dictionary<int, double>();

            foreach (var info in accountsInfo)
            {
                string[] singleAccInfo = info.Split("-", StringSplitOptions.RemoveEmptyEntries);

                int account = int.Parse(singleAccInfo[0]);
                double balance = double.Parse(singleAccInfo[1]);

                accounts.Add(account, balance);
            }

            string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != "End")
            {
                string command = cmdArgs[0];
                int account = int.Parse(cmdArgs[1]);
                double money = double.Parse(cmdArgs[2]);

                try
                {
                    switch (command)
                    {
                        case "Deposit":
                            accounts[account] += money;
                            break;
                        case "Withdraw":
                            if (accounts[account] < money)
                            {
                                throw new ArgumentException("Insufficient balance!");
                            }
                            accounts[account] -= money;
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {account} has new balance: {accounts[account]:f2}");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine($"Invalid account!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
