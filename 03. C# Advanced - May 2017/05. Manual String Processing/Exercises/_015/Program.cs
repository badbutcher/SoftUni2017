namespace _015
{
    using System;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine().Trim();
            string pattern = Console.ReadLine();

            bool canShake = true;

            while (canShake)
            {
                int indexFirst = input.IndexOf(pattern);
                int indexLast = input.LastIndexOf(pattern);
                if (indexFirst > -1 && indexLast > -1 && pattern.Length > 0)
                {
                    indexFirst = input.IndexOf(pattern);
                    input = input.Remove(indexFirst, pattern.Length);
                    indexLast = input.LastIndexOf(pattern);
                    input = input.Remove(indexLast, pattern.Length);
                    Console.WriteLine("Shaked it.");
                    if (pattern.Length > 0)
                    {
                        pattern = pattern.Remove(pattern.Length / 2, 1);
                    }
                }
                else
                {
                    Console.WriteLine("No shake.");
                    canShake = false;
                    Console.WriteLine(input);
                    break;
                }
            }
        }
    }
}