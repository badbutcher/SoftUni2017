using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010
{
    class Program
    {
        static void Main()
        {
            //string text = string.Empty;
            int n = int.Parse(Console.ReadLine());
            Queue<string> result = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "4")
                {

                }
                else
                {
                    string data = input[1];
                    if (input[0] == "1")
                    {
                        result.Enqueue(data);
                    }
                    else if (input[0] == "2")
                    {
                        int index = int.Parse(data);
                        //result.Dequeue(result)

                    }
                    else if (input[0] == "3")
                    {
                        int index = int.Parse(data);
                        Console.WriteLine(result.Peek().ElementAt(index - 1));
                    }
                }
            }
        }
    }
}