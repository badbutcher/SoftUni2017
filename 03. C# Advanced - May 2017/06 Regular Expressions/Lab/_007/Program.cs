namespace _007
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"^(\d{2}\:\d{2}\:\d{2}\s[AM]+|[PM]+)$";
            Regex regex = new Regex(pattern);

            while (true)
            {
                string text = Console.ReadLine();
                if (text == "END")
                {
                    break;
                }
                else
                {
                    MatchCollection matches = regex.Matches(text.ToString());
                    if (matches.Count == 0)
                    {
                        Console.WriteLine("invalid");
                    }
                    else
                    {
                        Console.WriteLine("valid");
                    }
                }
            }
        }
    }
}