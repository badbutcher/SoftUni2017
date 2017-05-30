using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[3][];
            int zero = 0;
            int one = 0;
            int two = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 3 == 0)
                {
                    zero++;
                }
                else if (input[i] % 3 == 1)
                {
                    one++;
                }
                else if (input[i] % 3 == 2)
                {
                    two++;
                }
            }

            matrix[0] = new int[zero];
            matrix[1] = new int[one];
            matrix[2] = new int[two];
            zero = 0;
            one = 0;
            two = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 3 == 0)
                {
                    matrix[0][zero] = input[i];
                    zero++;
                }
                else if (input[i] % 3 == 1)
                {
                    matrix[1][one] = input[i];
                    one++;
                }
                else if (input[i] % 3 == 2)
                {
                    matrix[2][two] = input[i];
                    two++;
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
        }
    }
}