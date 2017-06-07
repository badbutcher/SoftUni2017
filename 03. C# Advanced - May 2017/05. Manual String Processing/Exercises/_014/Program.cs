using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<decimal> result = new List<decimal>();
            for (int i = 0; i < input.Length; i++)
            {
                decimal number = 0;
                char firstLetter = input[i][0];
                char lastLetter = input[i][input[i].Length - 1];
                decimal numbers = decimal.Parse(input[i].Substring(1, input[i].Length - 2));
                number = numbers;
                if (char.IsUpper(firstLetter))
                {
                    char c = firstLetter;
                    int index = char.ToUpper(c) - 64;
                    number /= index;
                }
                else if (char.IsLower(firstLetter))
                {
                    char c = firstLetter;
                    int index = char.ToLower(c) - 96;
                    number *= index;
                }

                if (char.IsUpper(lastLetter))
                {
                    char c = lastLetter;
                    int index = char.ToUpper(c) - 64;
                    number -= index;
                }
                else if (char.IsLower(lastLetter))
                {
                    char c = lastLetter;
                    int index = char.ToLower(c) - 96;
                    number += index;
                }

                result.Add(number);
            }

            Console.WriteLine("{0:F2}", result.Sum());
        }
    }
}