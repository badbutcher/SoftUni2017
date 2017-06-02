using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[][] matrix = new char[input[0]][];
            Queue<int> currentBunnys = new Queue<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[input[1]];
                string area = Console.ReadLine();

                for (int j = 0; j < area.Length; j++)
                {
                    matrix[i][j] = area[j];
                }
            }

            string commands = Console.ReadLine();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        currentBunnys.Enqueue(row);
                        currentBunnys.Enqueue(col);
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    int bunnyRow = currentBunnys.Dequeue();
                    int bunnyCol = currentBunnys.Dequeue();
                    if (matrix[row][col] == 'B')
                    {
                        
                    }
                }
            }
        }
    }
}