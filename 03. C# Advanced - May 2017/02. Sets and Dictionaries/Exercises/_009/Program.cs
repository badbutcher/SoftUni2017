namespace _009
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> userLogs = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "end")
                {
                    break;
                }
                else
                {
                    string ip = input[0].Substring(3, input[0].Length - 3);
                    string message = input[1].Substring(9, input[1].Length - 10);
                    string user = input[2].Substring(5, input[2].Length - 5);

                    if (!userLogs.ContainsKey(user))
                    {
                        userLogs.Add(user, new Dictionary<string, int>());
                        userLogs[user].Add(ip, 0);
                    }

                    if (!userLogs[user].ContainsKey(ip))
                    {
                        userLogs[user].Add(ip, 1);
                    }
                    else
                    {
                        userLogs[user][ip]++;
                    }
                }
            }

            var result = userLogs.OrderBy(a => a.Key);

            foreach (var item in result)
            {
                Console.WriteLine(item.Key + ": ");

                StringBuilder sb = new StringBuilder();
                foreach (var inner in item.Value)
                {
                    sb.AppendFormat("{0} => {1}, ", inner.Key, inner.Value);
                }

                string print = sb.ToString().TrimEnd(new char[] { ',', ' ' });

                Console.WriteLine(print + ".");
            }
        }
    }
}