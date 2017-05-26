namespace _002
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            SortedSet<string> vips = new SortedSet<string>();
            SortedSet<string> regular = new SortedSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    break;
                }
                else
                {
                    if (char.IsDigit(input[0]))
                    {
                        vips.Add(input);
                    }
                    else if (input.Length == 8)
                    {
                        regular.Add(input);
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    if (char.IsDigit(input[0]))
                    {
                        vips.Remove(input);
                    }
                    else if (input.Length == 8)
                    {
                        regular.Remove(input);
                    }
                }
            }

            Console.WriteLine(vips.Count + regular.Count);

            foreach (var item in vips)
            {
                Console.WriteLine(item);
            }

            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}