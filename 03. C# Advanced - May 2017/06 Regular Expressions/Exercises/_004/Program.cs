namespace _004
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"<a (href=.+?)>(.*)<\/a>";
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
                    Match match = regex.Match(input);
                    if (match.Success)
                    {
                        sb.AppendFormat("[URL href={0}]{1}[/URL]", match.Groups[1], match.Groups[2]).Append(Environment.NewLine);
                    }
                    else
                    {
                        sb.AppendLine(input.Trim());
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}