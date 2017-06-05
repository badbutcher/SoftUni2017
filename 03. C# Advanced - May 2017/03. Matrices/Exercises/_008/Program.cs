namespace _008
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[][] matrix = new char[input[0]][];

            int playerRow = 0;
            int playerCol = 0;

            for (int i = 0; i < input[0]; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                if (matrix[i].Contains('P'))
                {
                    playerRow = i;
                    playerCol = Array.IndexOf(matrix[i], 'P');
                    matrix[playerRow][playerCol] = '.';
                }
            }

            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;
                switch (commands[i])
                {
                    case 'U':
                        playerRow -= 1;
                        break;
                    case 'D':
                        playerRow += 1;
                        break;
                    case 'L':
                        playerCol -= 1;
                        break;
                    case 'R':
                        playerCol += 1;
                        break;
                    default:
                        break;
                }

                matrix = SpreadBunnies(matrix, input[0] - 1, input[1] - 1);

                if (playerRow < 0 || playerRow >= input[0] ||
                    playerCol < 0 || playerCol >= input[1])
                {
                    PrintMatrix(matrix);
                    Console.WriteLine("won: {0} {1}", oldPlayerRow, oldPlayerCol);
                    break;
                }
                else if (matrix[playerRow][playerCol] == 'B')
                {
                    PrintMatrix(matrix);
                    Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
                    break;
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int k = 0; k < matrix.Length; k++)
            {
                for (int j = 0; j < matrix[k].Length; j++)
                {
                    if (matrix[k][j] == 'P')
                    {
                        matrix[k][j] = '.';
                    }
                    else
                    {
                        Console.Write(matrix[k][j]);
                    }
                }

                Console.WriteLine();
            }
        }

        private static char[][] SpreadBunnies(char[][] matrix, int rows, int cols)
        {
            var newLair = new char[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                newLair[i] = (char[])matrix[i].Clone();
            }

            for (int row = 0; row <= rows; row++)
            {
                for (int col = 0; col <= cols; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        if (row > 0)
                        {
                            newLair[row - 1][col] = 'B';
                        }

                        if (row < rows)
                        {
                            newLair[row + 1][col] = 'B';
                        }

                        if (col > 0)
                        {
                            newLair[row][col - 1] = 'B';
                        }

                        if (col < cols)
                        {
                            newLair[row][col + 1] = 'B';
                        }
                    }
                }
            }

            return newLair;
        }
    }
}