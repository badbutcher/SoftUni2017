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
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("\\u" + ((int)input[i]).ToString("X4").ToLower());
            }
        }
    }
}