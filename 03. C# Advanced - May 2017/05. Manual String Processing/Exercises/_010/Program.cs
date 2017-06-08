namespace _010
{
    using System;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("\\u" + ((int)input[i]).ToString("X4").ToLower());
            }
        }
    }
}