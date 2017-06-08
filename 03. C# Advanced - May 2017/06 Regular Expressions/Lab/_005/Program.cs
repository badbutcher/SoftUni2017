namespace _005
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"<.*?>";
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
                    MatchCollection matches = regex.Matches(text);
                    foreach (var item in matches)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}