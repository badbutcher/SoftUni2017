namespace _005
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Queue<double> result = new Queue<double>();
            double input = double.Parse(Console.ReadLine());

            double s1 = input;
            double s2 = s1 + 1;
            double s3 = 2 * s1 + 1;
            double s4 = s1 + 2;

            result.Enqueue(s1);
            result.Enqueue(s2);
            result.Enqueue(s3);
            result.Enqueue(s4);

            for (int i = 1; i <= 16; i++)
            {
                s2 = result.ElementAt(i) + 1;
                s3 = 2 * result.ElementAt(i) + 1;
                s4 = result.ElementAt(i) + 2;
                result.Enqueue(s2);

                if (i != 16)
                {
                    result.Enqueue(s3);
                    result.Enqueue(s4);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}