namespace _002
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nm[0];
            int m = nm[1];

            HashSet<int> nCount = new HashSet<int>();
            HashSet<int> mCount = new HashSet<int>();
            for (int j = 0; j < n; j++)
            {
                int nElement = int.Parse(Console.ReadLine());
                nCount.Add(nElement);
            }

            for (int j = 0; j < m; j++)
            {
                int mElement = int.Parse(Console.ReadLine());
                mCount.Add(mElement);
            }

            var result = nCount.Intersect(mCount);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}