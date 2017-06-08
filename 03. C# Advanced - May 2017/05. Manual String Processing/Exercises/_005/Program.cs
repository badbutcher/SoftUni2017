namespace _005
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
            string baseTenNum = input[1].ToString();
            baseTenNum = Reverse(baseTenNum);
            BigInteger result = 0;

            for (int i = 0; i < baseTenNum.Length; i++)
            {
                BigInteger value = (BigInteger)char.GetNumericValue(baseTenNum[i]) * BigInteger.Pow(baseN, i);
                result += value;
            }

            Console.WriteLine(result);
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}