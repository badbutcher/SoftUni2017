//namespace _002
//{
    using System;

    class Program
    {
        static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.ID = 1;
            acc.Deposit(15);
            acc.Withdraw(5);

            Console.WriteLine(acc.ToString());
        }
    }
//}