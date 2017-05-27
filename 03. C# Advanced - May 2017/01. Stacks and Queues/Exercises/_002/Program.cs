namespace _002
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> result = new Stack<int>();
            bool check = true;
            int elementsToPush = commands[0];
            int elementsToPop = commands[1];
            int elementToCheck = commands[2];

            if (elementsToPush <= n.Length)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    result.Push(n[i]);
                }
            }
            else
            {
                check = false;
            }

            if (elementsToPop <= result.Count && check)
            {
                for (int i = 0; i < elementsToPop; i++)
                {
                    result.Pop();
                }
            }
            else
            {
                check = false;
            }

            if (result.Contains(elementToCheck) && check)
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (check == true)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(result.OrderBy(a => a).FirstOrDefault());
            }
        }
    }
}