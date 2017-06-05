namespace _012
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string[] rotate = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            Queue<string> texts = new Queue<string>();
            int longestWord = 0;
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "END")
                {
                    break;
                }
                else
                {
                    if (text.Length > longestWord)
                    {
                        longestWord = text.Length;
                    }

                    texts.Enqueue(text);
                }
            }

            char[][] matrix = new char[texts.Count][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[longestWord];
                string word = texts.Dequeue();
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (j < word.Length)
                    {
                        matrix[i][j] = word[j];
                    }
                    else
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }

            int rotateNumber = Math.Abs(int.Parse(rotate[1]));
            int rotations = (rotateNumber % 360) / 90;
            if (rotations == 1)
            {
                char[][] finalMatrix = new char[matrix[0].Length][];

                for (int row = 0; row < finalMatrix.Length; row++)
                {
                    finalMatrix[row] = new char[matrix.Length];
                    for (int col = 0; col < finalMatrix[row].Length; col++)
                    {
                        finalMatrix[row][col] = matrix[matrix.Length - 1 - col][row];
                    }
                }

                foreach (var row in finalMatrix)
                {
                    Console.WriteLine(row);
                }
            }
            else if (rotations == 2)
            {
                for (int i = matrix.Length - 1; i >= 0; i--)
                {
                    Array.Reverse(matrix[i]);
                    Console.WriteLine(matrix[i]);
                }
            }
            else if (rotations == 3)
            {
                char[][] finalMatrix = new char[matrix[0].Length][];

                for (int row = 0; row < finalMatrix.Length; row++)
                {
                    finalMatrix[row] = new char[matrix.Length];
                    for (int col = 0; col < finalMatrix[row].Length; col++)
                    {
                        finalMatrix[row][col] = matrix[col][matrix[col].Length - 1 - row];
                    }
                }

                foreach (var row in finalMatrix)
                {
                    Console.WriteLine(row);
                }
            }
            else
            {
                foreach (var item in matrix)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}