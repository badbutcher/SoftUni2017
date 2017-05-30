namespace _004
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new long[i + 1];
                matrix[i][0] = 1;
                matrix[i][matrix[i].Length - 1] = 1;
            }

            for (int i = 0; i < n-1; i++)
            {
                if (i >= 1)
                {
                    for (int j = 0; j < matrix[i].Length-1; j++)
                    {
                        long left = matrix[i][j];
                        long right = matrix[i][j + 1];
                        matrix[i + 1][j+1] = left + right;
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}