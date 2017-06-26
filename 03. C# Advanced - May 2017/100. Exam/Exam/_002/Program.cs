using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            char[][] matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new char[n];
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {

                    matrix[i][j] = input[j];
                }
            }

            for (int row = 2; row < matrix.Length - 2; row++)
            {
                for (int col = 2; col < matrix[row].Length - 2; col++)
                {
                    if (matrix[row][col] == 'K')
                    {

                        if (matrix[row - 1][col + 2] != 'K' &&
                            matrix[row + 1][col + 2] != 'K' &&
                            matrix[row + 1][col - 2] != 'K' &&
                            matrix[row - 1][col - 2] != 'K' &&
                            matrix[row - 2][col - 1] != 'K' &&
                            matrix[row + 2][col + 1] != 'K' &&
                            matrix[row - 2][col - 1] != 'K' &&
                            matrix[row + 2][col + 1] != 'K')//???
                        {
                            count++;
                        }
                    }

                }
            }

            Console.WriteLine(count);
        }
    }
}