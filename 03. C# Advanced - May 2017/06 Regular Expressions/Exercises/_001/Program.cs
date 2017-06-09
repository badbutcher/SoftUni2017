namespace _001
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"([A-Z][a-z]{1,})\s([A-Z][a-z]{1,})";
            Regex regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                else
                {
                    Match match = regex.Match(input);
                    if (match.Success)
                    {
                        Console.WriteLine(match);
                    }
                }
            }
        }
    }
}