namespace _008
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            while (line != "END")
            {
                sb.Append(line).Append(" ");
                line = Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(sb.ToString(), @"<a\s+[^>]*?href\s*=\s*(.*?)>.*?<\s*\/\s*a\s*>");

            foreach (Match match in matches)
            {
                string candidateHref = match.Groups[1].ToString().Trim();

                if (candidateHref[0] == '"')
                {
                    Console.WriteLine(candidateHref.Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries).First());
                }
                else if (candidateHref[0] == '\'')
                {
                    Console.WriteLine(candidateHref.Split(new char[] { '\'' }, StringSplitOptions.RemoveEmptyEntries).First());
                }
                else
                {
                    Console.WriteLine(Regex.Split(candidateHref, @"\s+").First());
                }
            }
        }
    }
}