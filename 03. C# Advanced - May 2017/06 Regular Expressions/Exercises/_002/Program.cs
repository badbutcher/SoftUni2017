namespace _002
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"^\+359(-|\s)2\1[0-9]{3}\1[0-9]{4}$";
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