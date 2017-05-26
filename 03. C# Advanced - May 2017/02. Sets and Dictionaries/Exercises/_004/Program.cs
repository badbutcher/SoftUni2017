namespace _004
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<char, int> letters = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!letters.ContainsKey(input[i]))
                {
                    letters.Add(input[i], 0);
                }

                letters[input[i]]++;
            }

            foreach (var item in letters.OrderBy(a => a.Key))
            {
                Console.WriteLine("{0}: {1} time/s", item.Key, item.Value);
            }
        }
    }
}