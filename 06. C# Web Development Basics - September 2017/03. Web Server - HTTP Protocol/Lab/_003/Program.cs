namespace _003
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> paths = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    string path = data[0];
                    string method = data[1];

                    if (!paths.ContainsKey(path))
                    {
                        paths.Add(path, new List<string>());
                    }

                    paths[path].Add(method);
                }
            }

            string[] httpRequest = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string httpRequestCommand = httpRequest[0];
            string httpRequestPath = httpRequest[1].Trim('/');
            string http = httpRequest[2];

            bool check = paths.Any(a => a.Value.Contains(httpRequestPath));

            if (paths.ContainsKey(httpRequestPath) && check)
            {
                Console.WriteLine($"{http} 200 OK");
                Console.WriteLine($"Content-Length: 2");
                Console.WriteLine("Content-Type: text/plain");
                Console.WriteLine();
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine($"{http} 404 Not Found");
                Console.WriteLine($"Content-Length: 9");
                Console.WriteLine("Content-Type: text/plain");
                Console.WriteLine();
                Console.WriteLine("NotFound");
            }
        }
    }
}