using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012
{
    class Program
    {
        static void Main()
        {
            string[] rotate = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            Queue<string> texts = new Queue<string>();
            int textCount = 0;
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "END")
                {
                    break;
                }
                else
                {
                    texts.Enqueue(text);
                    textCount++;
                }
            }

            char[][] matrix = new char[texts.Count][];
            string longestWord = texts.Max();
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[texts.Peek().Length];
                string word = texts.Dequeue();
                for (int j = 0; j < word.Length; j++)
                {
                    matrix[i][j] = word[j];
                }
            }

            int rotateNumber = Math.Abs(int.Parse(rotate[1]));

            if (rotateNumber % 360 == 0 || rotateNumber == 0)
            {
                foreach (var item in matrix)
                {
                    Console.WriteLine(item);
                }
            }
            else if (rotateNumber % 180 == 0)
            {
                for (int i = matrix.Length - 1; i >= 0; i--)
                {
                    Array.Reverse(matrix[i]);
                    Console.WriteLine(matrix[i]);
                }
            }
            else if (rotateNumber % 270 == 0)
            {
                Console.WriteLine(270);
            }
            else if (rotateNumber % 90 == 0)
            {
                char[][] newMatrix = new char[longestWord.Length][];
                for (int i = 0; i < newMatrix.Length; i++)
                {
                    newMatrix[i] = new char[matrix.Length];
                }

                for (int row = 0; row < newMatrix.Length; row++)
                {
                    for (int col = 0; col < matrix.Length; col++)
                    {
                        newMatrix[row][col] = matrix[col][row];
                        Console.WriteLine(matrix[row][col]);
                    }
                }
            }   
        }
    }
}