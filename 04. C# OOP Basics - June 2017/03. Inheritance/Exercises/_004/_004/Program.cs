using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(new char[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                string artistName = data[0];
                string songName = data[1];
                int minutes = int.Parse(data[2]);
                int seconds = int.Parse(data[3]);
            }
        }
    }
}