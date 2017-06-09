namespace _003
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([A-Za-z])\1+";
            string result = string.Empty;

            Regex regex = new Regex(pattern);
            Console.WriteLine(Regex.Replace(input, pattern, "$1"));//Dolara zamenq grupata
        }
    }
}