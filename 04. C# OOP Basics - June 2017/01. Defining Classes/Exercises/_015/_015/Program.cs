using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (input == "Square")
            {
                int n = int.Parse(Console.ReadLine());
            }
            else if (input == "Rectangle")
            {
                int cols = int.Parse(Console.ReadLine());
                int rows = int.Parse(Console.ReadLine());
            }
        }
    }
}