namespace _001
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Format("{0, -10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                double num1 = double.Parse(input[1]);
                double num2 = double.Parse(input[2]);
                double num3 = double.Parse(input[3]);
                double avr = (num1 + num2 + num3) / 3;
                Console.WriteLine(string.Format("{0, -10}|{1,7:F2}|{2,7:F2}|{3,7:F2}|{4,7:F4}|", input[0], num1, num2, num3, avr));
            }
        }
    }
}