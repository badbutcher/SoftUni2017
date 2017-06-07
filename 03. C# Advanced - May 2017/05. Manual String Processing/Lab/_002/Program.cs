namespace _002
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length != 2 || input[1].IndexOf("/") < 0)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                string protocol = input[0].Trim();

                int spliter = 0;
                for (int i = 0; i < input[1].Length; i++)
                {
                    if (input[1][i].Equals('/'))
                    {
                        spliter = i;
                        break;
                    }
                }

                string server = input[1].Substring(0, spliter).Trim();
                string resources = input[1].Substring(spliter + 1).Trim();
                Console.WriteLine("Protocol = {0}", protocol);
                Console.WriteLine("Server = {0}", server);
                Console.WriteLine("Resources = {0}", resources);
            }
        }
    }
}