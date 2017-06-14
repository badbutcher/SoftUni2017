namespace _005
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else
                {
                    if (command == "add")
                    {
                        Func<int[], int[]> add = AddNums;
                        numbers = add(numbers);
                    }
                    else if (command == "multiply")
                    {
                        Func<int[], int[]> multiply = MultiplyNums;
                        numbers = multiply(numbers);
                    }
                    else if (command == "subtract")
                    {
                        Func<int[], int[]> subtract = SubtractNums;
                        numbers = subtract(numbers);
                    }
                    else if (command == "print")
                    {
                        Console.WriteLine(string.Join(" ", numbers));
                    }
                }
            } 
        }

        private static int[] SubtractNums(int[] arg)
        {
            int[] result = new int[arg.Length];

            for (int i = 0; i < arg.Length; i++)
            {
                result[i] = arg[i] - 1;
            }

            return result;
        }

        private static int[] MultiplyNums(int[] arg)
        {
            int[] result = new int[arg.Length];

            for (int i = 0; i < arg.Length; i++)
            {
                result[i] = arg[i] * 2;
            }

            return result;
        }

        private static int[] AddNums(int[] arg)
        {
            int[] result = new int[arg.Length];

            for (int i = 0; i < arg.Length; i++)
            {
                result[i] = arg[i] + 1;
            }

            return result;
        }
    }
}