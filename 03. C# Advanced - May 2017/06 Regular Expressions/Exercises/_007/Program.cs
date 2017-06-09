namespace _007
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\b([a-zA-Z][\w]{2,25})\b";

            int currentLongest = 0;
            string firstLongest = string.Empty;
            string secondLongest = string.Empty;

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            List<string> items = new List<string>();

            foreach (var item in matches)
            {
                items.Add(item.ToString());
            }

            for (int i = 1; i < items.Count; i++)
            {
                string a = items[i - 1];
                string b = items[i];
                int totalLenght = a.Length + b.Length;
                if (totalLenght > currentLongest)
                {
                    currentLongest = totalLenght;
                    firstLongest = a;
                    secondLongest = b;
                }
            }

            Console.WriteLine(firstLongest);
            Console.WriteLine(secondLongest);
        }
    }
}