namespace _001
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[][] matrix = new string[input[0]][];

            for (int i = 0; i < input[0]; i++)
            {
                matrix[i] = new string[input[1]];
            }

            char colChar = 'a';

            for (char row = 'a'; row < matrix.Length + 'a'; row++)
            {
                for (char col = colChar; col < input[1] + colChar; col++)
                {
                    Console.Write("{0}{1}{0} ", row, col);
                }

                colChar++;
                Console.WriteLine();
            }
        }
    }
}