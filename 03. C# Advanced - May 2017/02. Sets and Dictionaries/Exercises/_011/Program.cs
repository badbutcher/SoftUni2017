namespace _011
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> logs = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string ip = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);

                if (!logs.ContainsKey(user))
                {
                    logs.Add(user, new Dictionary<string, int>());
                    logs[user].Add(ip, 0);
                }

                if (!logs[user].ContainsKey(ip))
                {
                    logs[user].Add(ip, duration);
                }
                else
                {
                    logs[user][ip] += duration;
                }
            }

            var result = logs.OrderBy(a => a.Key);

            foreach (var item in result)
            {
                Console.Write("{0}: {1} ", item.Key, item.Value.Values.Sum());

                var sort = item.Value.OrderBy(a => a.Key);

                StringBuilder sb = new StringBuilder();
                sb.Append("[");

                foreach (var inner in sort)
                {
                    sb.AppendFormat("{0}, ", inner.Key);
                }

                string print = sb.ToString().TrimEnd(new char[] { ' ', ',' });

                Console.WriteLine(print + "]");
            }
        }
    }
}