//namespace _002
//{
using System;

public class Program
{
    public static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.Id = 1;
        acc.Deposit(15);
        acc.Withdraw(5);

        Console.WriteLine(acc.ToString());
    }
}

//}