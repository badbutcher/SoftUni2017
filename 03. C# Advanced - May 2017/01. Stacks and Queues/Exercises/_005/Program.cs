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

            double S1 = input;
            double S2 = S1 + 1;
            double S3 = 2 * S1 + 1;
            double S4 = S1 + 2;

            result.Enqueue(S1);
            result.Enqueue(S2);
            result.Enqueue(S3);
            result.Enqueue(S4);

            for (int i = 1; i <= 16; i++)
            {
                S2 = result.ElementAt(i) + 1;
                S3 = 2 * result.ElementAt(i) + 1;
                S4 = result.ElementAt(i) + 2;
                result.Enqueue(S2);

                if (i != 16)
                {
                    result.Enqueue(S3);
                    result.Enqueue(S4);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}