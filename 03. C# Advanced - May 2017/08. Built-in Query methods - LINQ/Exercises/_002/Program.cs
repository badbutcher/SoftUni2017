namespace _002
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
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

                var sort = result.Where(c => c[0].CompareTo(c[1]) < 0);

                foreach (var item in sort)
                {
                    Console.WriteLine("{0} {1}", item[0], item[1]);
                }
            }
        }
    }
}