namespace _005
{
    using System;
    using System.Text;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                sb.AppendFormat("{0} ", input);
            }

            Console.WriteLine(sb);
        }
    }
}