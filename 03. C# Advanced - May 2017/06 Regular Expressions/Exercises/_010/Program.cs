namespace _010
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"<p>(.*?)<\/p>";
            string replacePattern = @"[^a-z0-9]+";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            List<string> tags = new List<string>();
            foreach (Match item in matches)
            {
                var replace = Regex.Replace(item.Groups[1].Value, replacePattern, " ");
                replace = Regex.Replace(replace, "\\s+", " ");
                tags.Add(replace);
            }

            string result = string.Empty;
            foreach (var item in tags)
            {
                string text = string.Empty;
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] >= 'a' && item[i] <= 'm')
                    {
                        text += (char)(item[i] + 13);
                    }
                    else if (item[i] >= 'n' && item[i] <= 'z')
                    {
                        text += (char)(item[i] - 13);
                    }
                    else if (char.IsDigit(item[i]) || char.IsWhiteSpace(item[i]))
                    {
                        text += item[i];
                    }
                }

                result += text;
            }

            Console.WriteLine(result);
        }
    }
}