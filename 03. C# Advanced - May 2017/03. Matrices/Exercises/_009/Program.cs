namespace _009
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[input[0]][];
            int counter = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[input[1]];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = counter++;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Nuke it from orbit")
                {
                    break;
                }
                else
                {
                    int[] nukes = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    int nukeRow = nukes[0];
                    int nukeCol = nukes[1];
                    int nukeRadius = nukes[2];

                    for (int row = nukeRow - nukeRadius; row <= nukeRow + nukeRadius; row++)
                    {
                        if (row >= 0 && row < matrix.Length)
                        {
                            if (nukeCol >= 0 && nukeCol < matrix[row].Length)
                            {
                                matrix[row][nukeCol] = 0;
                            }
                        }

                        for (int col = nukeCol - nukeRadius; col <= nukeCol + nukeRadius; col++)
                        {
                            if (nukeRow < 0 || nukeRow >= matrix.Length)
                            {
                                continue;
                            }
                            if (col >= 0 && col < matrix[nukeRow].Length)
                            {
                                matrix[nukeRow][col] = 0;
                            }
                        }
                    }

                    for (int row = 0; row < matrix.Length; row++)
                    {
                        matrix[row] = matrix[row].Where(val => val != 0).ToArray();
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                if (matrix[i].Length != 0)
                {
                    Console.WriteLine();
                }
            }         
        }
    }
}