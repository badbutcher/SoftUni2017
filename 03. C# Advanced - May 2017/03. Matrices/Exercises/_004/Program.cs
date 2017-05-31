namespace _004
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[input[0]][];
            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currentSum =
                        matrix[row][col] +
                        matrix[row][col + 1] +
                        matrix[row][col + 2] +
                        matrix[row + 1][col] +
                        matrix[row + 1][col + 1] +
                        matrix[row + 1][col + 2] +
                        matrix[row + 2][col] +
                        matrix[row + 2][col + 1] +
                        matrix[row + 2][col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);
            Console.WriteLine("{0} {1} {2}\n{3} {4} {5}\n{6} {7} {8}",
                matrix[maxRow][maxCol],
                matrix[maxRow][maxCol + 1],
                matrix[maxRow][maxCol + 2],
                matrix[maxRow + 1][maxCol],
                matrix[maxRow + 1][maxCol + 1],
                matrix[maxRow + 1][maxCol + 2],
                matrix[maxRow + 2][maxCol],
                matrix[maxRow + 2][maxCol + 1],
                matrix[maxRow + 2][maxCol + 2]
                );
        }
    }
}