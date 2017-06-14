namespace _007
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<List<string>, int, List<string>> res = GetNames;

            var print = res(names, lenght);

            foreach (var item in print)
            {
                Console.WriteLine(item);
            }
        }

        private static List<string> GetNames(List<string> arg, int lenght)
        {
            List<string> res = new List<string>();
            foreach (var item in arg)
            {
                if (item.Length <= lenght)
                {
                    res.Add(item);
                }
            }

            return res;
        }
    }
}