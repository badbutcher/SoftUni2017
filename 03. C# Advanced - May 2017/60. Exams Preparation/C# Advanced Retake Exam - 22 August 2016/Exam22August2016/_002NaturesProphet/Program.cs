namespace _002NaturesProphet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] matrix = FillMatrix(rows, cols);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Bloom Bloom Plow")
                {
                    break;
                }
                else
                {
                    var commandTokens = command.Split().Select(int.Parse).ToArray();
                    var rowImpact = commandTokens[0];
                    var colImpact = commandTokens[1];

                    for (int rowIndex = 0; rowIndex <= matrix.Length; rowIndex++)
                    {
                        if (IsInMatrix(rowIndex, colImpact, matrix))
                        {
                            if (rowImpact != rowIndex)
                            {
                                matrix[rowIndex][colImpact] += 1;
                            }
                        }
                    }

                    for (int colIndex = 0; colIndex <= matrix.Length; colIndex++)
                    {
                        if (IsInMatrix(rowImpact, colIndex, matrix))
                        {
                            matrix[rowImpact][colIndex] += 1;
                        }
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static bool IsInMatrix(int currentRow, int currentCol, int[][] matrix)
        {
            if (currentRow >= 0 && currentRow < matrix.Length && currentCol >= 0 && currentCol < matrix[currentRow].Length)
            {
                return true;
            }

            return false;
        }

        private static int[][] FillMatrix(int rows, int cols)
        {
            int[][] matrix = new int[rows][];

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[rows];
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex][colIndex] = 0;
                }
            }

            return matrix;
        }
    }
}


//namespace _002NaturesProphet
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    class Program
//    {
//        static void Main()
//        {
//            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

//            int rows = dimensions[0];
//            int cols = dimensions[1];

//            List<List<int>> matrix = FillMatrix(rows, cols);

//            while (true)
//            {
//                string command = Console.ReadLine();

//                if (command == "Bloom Bloom Plow")
//                {
//                    break;
//                }
//                else
//                {
//                    var commandTokens = command.Split().Select(int.Parse).ToArray();
//                    var rowImpact = commandTokens[0];
//                    var colImpact = commandTokens[1];

//                    for (int rowIndex = 0; rowIndex <= matrix.Count; rowIndex++)
//                    {
//                        if (IsInMatrix(rowIndex, colImpact, matrix))
//                        {
//                            if (rowImpact != rowIndex)
//                            {
//                                matrix[rowIndex][colImpact] += 1;
//                            }
//                        }
//                    }

//                    for (int colIndex = 0; colIndex <= matrix.Count; colIndex++)
//                    {
//                        if (IsInMatrix(rowImpact, colIndex, matrix))
//                        {
//                            //if (colImpact != colIndex)
//                            //{
//                            matrix[rowImpact][colIndex] += 1;
//                            //}
//                        }
//                    }
//                }
//            }

//            PrintMatrix(matrix);
//        }

//        private static void PrintMatrix(List<List<int>> matrix)
//        {
//            for (int i = 0; i < matrix.Count; i++)
//            {
//                Console.WriteLine(string.Join(" ", matrix[i]));
//            }
//        }

//        private static bool IsInMatrix(int currentRow, int currentCol, List<List<int>> matrix)
//        {
//            if (currentRow >= 0 && currentRow < matrix.Count && currentCol >= 0 && currentCol < matrix[currentRow].Count)
//            {
//                return true;
//            }

//            return false;
//        }

//        private static List<List<int>> FillMatrix(int rows, int cols)
//        {
//            List<List<int>> matrix = new List<List<int>>();

//            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
//            {
//                matrix.Add(new List<int>());
//                for (int colIndex = 0; colIndex < cols; colIndex++)
//                {
//                    matrix[rowIndex].Add(0);
//                }
//            }

//            return matrix;
//        }
//    }
//}