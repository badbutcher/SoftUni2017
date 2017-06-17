namespace _005
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

            var sort = result.Where(a => a[2].Contains("@gmail.com"));

            foreach (var item in sort)
            {
                Console.WriteLine("{0} {1}", item[0], item[1]);
            }
        }
    }
}