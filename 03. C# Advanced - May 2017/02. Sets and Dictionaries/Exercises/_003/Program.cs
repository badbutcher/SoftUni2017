namespace _003
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> names = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] name = Console.ReadLine().Split();
                for (int j = 0; j < name.Length; j++)
                {
                    names.Add(name[j]);
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}