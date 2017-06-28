namespace _003
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();
                    int id = int.Parse(data[1]);
                    BankAccount acc = new BankAccount();
                    switch (data[0])
                    {
                        case "Create":
                            Create(id, accounts);
                            break;
                        case "Deposit":
                            Deposit(id, double.Parse(data[2]), accounts);
                            break;
                        case "Withdraw":
                            Withdraw(id, double.Parse(data[2]), accounts);
                            break;
                        case "Print":
                            Print(id, accounts);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void Print(int id, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id].ToString());
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(int id, double amount, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(id))
            {
                if (accounts[id].Balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    accounts[id].Withdraw(amount);
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(int id, double amount, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(int id, Dictionary<int, BankAccount> accounts)
        {
            if (!accounts.ContainsKey(id))
            {
                BankAccount acc = new BankAccount();
                acc.ID = id;
                accounts.Add(id, acc);
            }
            else
            {
                Console.WriteLine("Account already exists");
            }
        }
    }
}