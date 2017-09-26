namespace _001
{
    using System;
    using System.Web;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Console.WriteLine(HttpUtility.UrlDecode(input));
        }
    }
}