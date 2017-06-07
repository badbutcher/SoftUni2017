namespace _004
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split();
            string[] text = Console.ReadLine().Split(new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> counter = new Dictionary<string, int>();
            foreach (var item in words)
            {
                counter.Add(item, 0);
            }

            foreach (var item in text)
            {
                if (words.Any(a => a == item))
                {
                    counter[item]++;
                }
            }

            foreach (var item in counter)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
    }
}