namespace _007
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"^([01][0-9]):([012345][0-9]):([012345][0-9]) [AP]M$";
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