namespace _003
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[][] matrix = new char[input[0]][];
            int counter = 0;

            for (int i = 0; i < input[0]; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(char.Parse).ToArray();
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var check = new[] {
                        matrix[row][col],
                        matrix[row][col + 1],
                        matrix[row + 1][col],
                        matrix[row + 1][col + 1]
                    }.All(x => x == matrix[row][col]);

                    if (check)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}