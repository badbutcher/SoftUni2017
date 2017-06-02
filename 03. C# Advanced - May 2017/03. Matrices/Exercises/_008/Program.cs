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
            
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _008
//{
//    class Program
//    {
//        static void Main()
//        {
//            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
//            int[][] matrix = new int[input[0]][];
//            int counter = 1;
//            for (int i = 0; i < matrix.Length; i++)
//            {
//                matrix[i] = new int[input[1]];

//                for (int j = 0; j < matrix[i].Length; j++)
//                {
//                    matrix[i][j] = counter++;
//                }
//            }

//            while (true)
//            {
//                string command = Console.ReadLine();
//                if (command == "Nuke it from orbit")
//                {
//                    break;
//                }
//                else
//                {
//                    int[] nukes = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
//                    int nukeRow = nukes[0];
//                    int nukeCol = nukes[1];
//                    int nukeRadius = nukes[2];

//                    for (int row = 0; row < matrix.Length; row++)
//                    {
//                        if (row == nukeRow)
//                        {
//                            for (int i = nukeRow - nukeRadius; i < matrix[row].Length; i++)
//                            {
//                                matrix[row][i] = 0;
//                            }
//                        }

//                        for (int col = 0; col < matrix[row].Length; col++)
//                        {
//                            if (col == nukeCol && (row >= nukeRow - nukeRadius && row <= matrix[row].Length))
//                            {
//                                Console.WriteLine(matrix[row][nukeCol]);
//                                matrix[row][nukeCol] = 0;

//                            }

//                            //matrix[col] = matrix[col].Where(val => val != 0).ToArray();
//                        }

//                        matrix[row] = matrix[row].Where(val => val != 0).ToArray();
//                    }
//                }
//            }

//            for (int i = 0; i < matrix.Length; i++)
//            {
//                for (int j = 0; j < matrix[i].Length; j++)
//                {
//                    Console.Write(matrix[i][j] + " ");
//                }

//                Console.WriteLine();
//            }
//        }
//    }
//}