using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _012
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            string left = input[0];
            string right = input[1];

            int shortest = Math.Min(left.Length, right.Length);
            int longest = Math.Max(left.Length, right.Length);
            BigInteger sum = 0;
            for (int i = 0; i < shortest; i++)
            {
                sum += left[i] * right[i];
            }

            if (left.Length < right.Length)
            {
                for (int i = shortest; i < longest; i++)
                {
                    sum += right[i];
                }
            }
            else
            {
                for (int i = shortest; i < longest; i++)
                {
                    sum += left[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}