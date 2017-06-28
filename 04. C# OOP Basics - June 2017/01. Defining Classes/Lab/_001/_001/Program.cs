//namespace _001
//{
    using System;

    public class Program
    {
        static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.ID = 1;
            acc.Balance = 15;

            Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
        }
    }
//}