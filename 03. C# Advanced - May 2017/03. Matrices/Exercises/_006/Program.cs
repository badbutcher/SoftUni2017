using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string text = string.Empty;
            text = Console.ReadLine();
            int[] bombInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[][] matrix = new char[input[0]][];
            for (int i = 0; i < input[0]; i++)
            {
                matrix[i] = new char[input[1]];
            }

            text = GetTextLenght(input, text);

            FillMatrix(text, matrix);

            CleanMatrix(bombInfo, matrix);

            DropCharacters(matrix);

            Print(matrix);
        }

        private static void Print(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void DropCharacters(char[][] matrix)
        {
            int width = matrix[0].Length;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                for (int column = 0; column < width; column++)
                {
                    if (matrix[row][column] != ' ')
                    {
                        continue;
                    }

                    int currentRow = row - 1;
                    while (currentRow >= 0)
                    {
                        if (matrix[currentRow][column] != ' ')
                        {
                            matrix[row][column] = matrix[currentRow][column];
                            matrix[currentRow][column] = ' ';
                            break;
                        }

                        currentRow--;
                    }
                }
            }
        }

        private static void CleanMatrix(int[] bombInfo, char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var bomb = ((row - bombInfo[0]) * (row - bombInfo[0]) + (col - bombInfo[1]) * (col - bombInfo[1]));
                    if (bomb <= bombInfo[2] * bombInfo[2])
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static string GetTextLenght(int[] input, string text)
        {
            while (true)
            {
                if (text.Length >= input[0] * input[1])
                {
                    text = text.Substring(0, input[0] * input[1]);
                    break;
                }
                else
                {
                    text += text;
                }
            }

            return text;
        }

        private static void FillMatrix(string text, char[][] matrix)
        {
            int textCount = 0;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (row % 2 == 0)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        matrix[row][col] = text[textCount++];
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = text[textCount++];
                    }
                }
            }
        }
    }
}