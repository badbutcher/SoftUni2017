namespace _002
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Web;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string decodedUrl = HttpUtility.UrlDecode(input);

            Uri uri = new Uri(decodedUrl);

            if (Uri.IsWellFormedUriString(decodedUrl, UriKind.Absolute))
            {
                Console.WriteLine($"Protocol: {uri.Scheme}");
                Console.WriteLine($"Host: {uri.Host}");
                Console.WriteLine($"Port: {uri.Port}");
                Console.WriteLine($"Path: {uri.LocalPath}");
                Console.WriteLine($"Query: {uri.Query}");
                Console.WriteLine($"Fragment: {uri.Fragment}");
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}