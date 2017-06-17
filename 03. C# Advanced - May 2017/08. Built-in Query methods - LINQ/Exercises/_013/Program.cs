namespace _013
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> office = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Trim('|').Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                string company = input[0];
                int amount = int.Parse(input[1]);
                string product = input[2];

                if (!office.ContainsKey(company))
                {
                    office.Add(company, new Dictionary<string, int>());
                }

                if (!office[company].ContainsKey(product))
                {
                    office[company].Add(product, 0);
                }

                office[company][product] += amount;
            }

            var result = office.OrderBy(a => a.Key);

            StringBuilder sb = new StringBuilder();
            foreach (var company in result)
            {
                sb.Append(company.Key + ": ");
                foreach (var item in company.Value)
                {
                    sb.AppendFormat("{0}-{1}, ", item.Key, item.Value);
                }

                Console.WriteLine(sb.ToString().TrimEnd(new char[] { ' ', ',' }));
                sb.Clear();
            }
        }
    }
}