namespace _006
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = string.Format(@"\s*(.*?\b{0}\b.*?[.!?])", word);
            //string pattern = @"[A-Z][a-z\s]+[^\!\.\?]+[\!\.\?]";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (var item in matches)
            {
                Console.WriteLine(item.ToString().Trim());
            }
        }
    }
}