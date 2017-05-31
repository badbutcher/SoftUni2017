namespace _007
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrixOne = new int[n][];
            int[][] matrixTwo = new int[n][];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                matrixOne[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sum += matrixOne[i].Length;
            }

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Array.Reverse(arr);
                matrixTwo[i] = arr;
                sum += matrixTwo[i].Length;
            }

            int arr1 = matrixOne[0].Length;
            int arr2 = matrixTwo[0].Length;

            bool sqr = false;
            for (int i = 1; i < n; i++)
            {
                if (matrixOne[i].Length + matrixTwo[i].Length == arr1 + arr2)
                {
                    sqr = true;
                }
                else
                {
                    sqr = false;
                    break;
                }
            }

            if (sqr)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("[{0}, {1}]", string.Join(", ", matrixOne[i]), string.Join(", ", matrixTwo[i]));
                }
            }
            else
            {

                Console.WriteLine("The total number of cells is: {0}", sum);
            }
        }
    }
}