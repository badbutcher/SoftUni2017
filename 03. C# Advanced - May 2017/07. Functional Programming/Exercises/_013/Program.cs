namespace _013
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

            Func<string, int, bool> res = Equal;
            foreach (var item in names)
            {
                if (res(item, lenght))
                {
                    Console.WriteLine(item);
                    break;
                }
            }
        }

        private static bool Equal(string name, int lenght)
        {
            int sum = 0;

            for (int i = 0; i < name.Length; i++)
            {
                sum += name[i];
            }

            if (sum >= lenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}