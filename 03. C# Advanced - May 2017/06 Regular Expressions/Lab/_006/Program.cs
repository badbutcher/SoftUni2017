namespace _006
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"^[\w\d-]{3,16}$";
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