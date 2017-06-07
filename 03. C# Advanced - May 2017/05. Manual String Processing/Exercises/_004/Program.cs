namespace _004
{
    using System;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            BigInteger[] input = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();

            BigInteger baseN = input[0];
            BigInteger baseTenNum = input[1];
            string result = string.Empty;
            BigInteger leftOver = 0;

            if (baseN >= 2 && baseN <= 10)
            {
                while (baseTenNum > 0)
                {
                    leftOver = baseTenNum % baseN;
                    baseTenNum /= baseN;

                    result = leftOver.ToString() + result;
                }

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}