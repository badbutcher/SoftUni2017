namespace _005
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<![\.\-])([a-zA-Z0-9\.\-]+)@([a-zA-Z\-]+)\.([a-zA-Z\-\.]+)\b";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}