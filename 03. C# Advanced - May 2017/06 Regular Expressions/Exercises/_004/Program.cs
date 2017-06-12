namespace _004
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"<a (href=.+?)>(.+)<\/a>";
            Regex regex = new Regex(pattern);
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                else
                {
                    sb.AppendLine(input);
                }
            }

            var result = Regex.Replace(sb.ToString(), pattern, w => $"[URL {w.Groups[1]}]{w.Groups[2]}[/URL]");

            Console.WriteLine(result);
        }
    }
}