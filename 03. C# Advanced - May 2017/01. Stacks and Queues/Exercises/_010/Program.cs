namespace _010
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> result = new Stack<string>();
            result.Push(string.Empty);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "4")
                {
                    result.Pop();
                }
                else
                {
                    string data = input[1];
                    if (input[0] == "1")
                    {
                        string text = result.Peek();
                        text += data;
                        result.Push(text);
                    }
                    else if (input[0] == "2")
                    {
                        int index = int.Parse(data);
                        string peek = result.Peek().ToString();
                        result.Push(peek.Substring(0, peek.Length - index));
                    }
                    else if (input[0] == "3")
                    {
                        int index = int.Parse(data) - 1;
                        Console.WriteLine(result.Peek()[index]);
                    }
                }
            }
        }
    }
}