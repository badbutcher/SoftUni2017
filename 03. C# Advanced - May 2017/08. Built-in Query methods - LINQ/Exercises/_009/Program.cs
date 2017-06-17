namespace _009
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string[]> result = new List<string[]>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();
                    result.Add(data);
                }
            }

            var sort = result.Where(a => a[0].Substring(4).Equals("14") || a[0].Substring(4).Equals("15"));

            foreach (var item in sort)
            {
                Console.WriteLine(string.Join(" ", item.Skip(1)));
            }
        }
    }
}