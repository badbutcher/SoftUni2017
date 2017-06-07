namespace _007
{
    using System;

    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if (a.Length > b.Length)
            {
                b = b.PadLeft(a.Length, '0');
            }
            else if (a.Length < b.Length)
            {
                a = a.PadLeft(b.Length, '0');
            }

            string result = string.Empty;
            int leftOver = 0;
            bool leftOverFound = false;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int numSum = int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()) + leftOver;
                if (leftOverFound)
                {
                    numSum -= leftOver - 1;
                    leftOver = 0;
                    leftOverFound = false;
                }

                if (numSum >= 10)
                {
                    leftOver = numSum - 9;
                    result += numSum - 10;
                    leftOverFound = true;
                }
                else
                {
                    result += numSum;
                }
            }

            if (leftOver > 0)
            {
                result += leftOver;
            }

            Console.WriteLine(Reverse(result).TrimStart('0'));
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}