using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length > 2)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                string protocol = input[0];

                int spliter = 0;
                for (int i = 0; i < input[1].Length; i++)
                {
                    Console.WriteLine(input[i]);
                }

                string server = input[1].Substring(spliter);
                Console.WriteLine("Protocol = {0}", protocol);
                Console.WriteLine("Server = {0}", server);
                //Console.WriteLine("Resources = {0}", input[2]);
            }
        }
    }
}