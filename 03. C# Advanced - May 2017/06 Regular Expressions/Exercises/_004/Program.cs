namespace _004
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"(<a href=)(.*)(<\/a>)";
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
                        string href = match.Groups[2].Value.Replace('>', ']');
                        Console.WriteLine("[URL href={0}[/URL]", href);
                    }
                    else
                    {
                        Console.WriteLine(input);
                    }
                }
            }
        }
    }
}