namespace _003
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"."; //([A-Za-z])\1+
            string result = string.Empty;

            Regex regex = new Regex(pattern);
            MatchCollection match = regex.Matches(input);

            result += match[0];
            int next = 0;
            for (int i = 1; i < match.Count; i++)
            {
                if (match[i].Value != result[next].ToString())
                {
                    result += match[i];
                    next++;
                }
            }

            Console.WriteLine(result);
        }
    }
}