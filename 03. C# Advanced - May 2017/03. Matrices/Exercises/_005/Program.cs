using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    class Program
    {
        static void Main()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new int[rows][];

            var count = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];

                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex][colIndex] = count++;
                }
            }

            var commandsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNum; i++)
            {
                var commandTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var rcIndex = int.Parse(commandTokens[0]);
                var direction = commandTokens[1];
                var moves = int.Parse(commandTokens[2]);

                switch (direction)
                {
                    case "up":
                        MoveCol(matrix, rcIndex, moves);
                        break;
                    case "down":
                        MoveCol(matrix, rcIndex, rows - moves % rows);
                        break;
                    case "left":
                        MoveRow(matrix, rcIndex, moves);
                        break;
                    case "right":
                        MoveRow(matrix, rcIndex, cols - moves % cols);
                        break;
                    default:
                        break;
                }
            }

            var element = 1;
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    var currentElement = matrix[rowIndex][colIndex];
                                    matrix[rowIndex][colIndex] = element;
                                    matrix[r][c] = currentElement;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                }
                            }
                        }
                    }

                    element++;
                }
            }
        }

        private static void MoveRow(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix[0].Length];
            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            {
                temp[colIndex] = matrix[rcIndex][(colIndex + moves) % matrix[0].Length];
            }

            matrix[rcIndex] = temp;
        }

        private static void MoveCol(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix.Length];
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                temp[rowIndex] = matrix[(rowIndex + moves) % matrix.Length][rcIndex];
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex][rcIndex] = temp[rowIndex];
            }
        }
    }
}