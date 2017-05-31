namespace _002
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (row == col)
                    {
                        primaryDiagonal += matrix[row][col];
                    }

                    if (row + col + 1 == matrix.Length)
                    {
                        secondaryDiagonal += matrix[row][col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}