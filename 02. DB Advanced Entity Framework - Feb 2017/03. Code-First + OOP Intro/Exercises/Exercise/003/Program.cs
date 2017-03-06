using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Family f = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                f.AddMember(new Person(input[0], int.Parse(input[1])));
            }

            Console.WriteLine(f.GetOldestMember().Name + " " + f.GetOldestMember().Age);
        }
    }
}
