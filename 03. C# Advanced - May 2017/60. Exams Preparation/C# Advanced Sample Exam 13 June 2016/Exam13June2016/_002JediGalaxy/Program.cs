using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int matrixCounter = 0;
            int[][] matrix = new int[matrixSize[0]][];
            int playerPoints = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[matrixSize[1]];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = matrixCounter++;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Let the Force be with you")
                {
                    break;
                }
                else
                {
                    int[] player = input.Split().Select(int.Parse).ToArray();
                    int[] enemy = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    int playerRow = player[0];
                    int playerCol = player[1];
                    int enemyRow = enemy[0];
                    int enemyCol = enemy[1];

                    while (enemyRow >= 0 && enemyCol >= 0)
                    {
                        if (IsInMatrix(matrix, enemyRow, enemyCol))
                        {
                            matrix[enemyRow][enemyCol] = 0;
                        }

                        enemyRow--;
                        enemyCol--;
                    }

                    while (playerRow >= 0 && playerCol < input[1])
                    {
                        if (IsInMatrix(matrix, playerRow, playerCol))
                        {
                            playerPoints += matrix[playerRow][playerCol];
                        }

                        playerRow--;
                        playerCol++;
                    }
                }
            }

            Console.WriteLine(playerPoints);
        }

        private static bool IsInMatrix(int[][] matrix, int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < matrix.Length && currentCol >= 0 && currentCol < matrix[currentRow].Length)
            {
                return true;
            }

            return false;
        }

        private static void FillMatrix(int[] matrixDimensions, int[][] matrix)
        {
            int matrixCounter = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[matrixDimensions[1]];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = matrixCounter++;
                }
            }
        }
    }
}