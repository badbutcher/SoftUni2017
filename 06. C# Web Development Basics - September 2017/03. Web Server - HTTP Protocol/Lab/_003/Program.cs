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


//private const int ResponseNotFoundCode = 404;
//private const string ResponseNotFoundMessage = "Not Found";
//private const int ResponseStatusOkCode = 200;
//private const string ResponseStatusOkMessage = "OK";

//public static void Main()
//{
//    Dictionary<string, HashSet<string>> validUrls = new Dictionary<string, HashSet<string>>();

//    string input = string.Empty;
//    while ((input = Console.ReadLine()) != "END")
//    {
//        string[] tokens = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

//        string path = $"/{tokens[0]}";
//        string method = tokens[1];

//        if (!validUrls.ContainsKey(path))
//        {
//            validUrls[path] = new HashSet<string>();
//        }

//        validUrls[path].Add(method);
//    }

//    string request = Console.ReadLine();

//    string[] requestParts = request.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//    string requestMethod = requestParts[0].ToLower();
//    string requestPath = requestParts[1];
//    string requestProtocol = requestParts[2];

//    if (validUrls.ContainsKey(requestPath) && validUrls[requestPath].Contains(requestMethod))
//    {
//        Console.WriteLine($"{requestProtocol} {ResponseStatusOkCode} {ResponseStatusOkMessage}");
//        Console.WriteLine($"Content-Length: {ResponseStatusOkMessage.Length}");
//        Console.WriteLine($"Content-Type: text/plain");
//        Console.WriteLine($"{Environment.NewLine}{ResponseStatusOkMessage}");
//    }
//    else
//    {
//        Console.WriteLine($"{requestProtocol} {ResponseNotFoundCode} {ResponseNotFoundMessage}");
//        Console.WriteLine($"Content-Length: {ResponseNotFoundMessage.Length}");
//        Console.WriteLine($"Content-Type: text/plain");
//        Console.WriteLine($"{Environment.NewLine}{ResponseNotFoundMessage}");
//    }
//}