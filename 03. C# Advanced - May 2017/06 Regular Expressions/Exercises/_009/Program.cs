using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _009
{
    class Program
    {
        static void Main()
        {
            string pattern = @"([A-Za-z0-9+%20]+)=([A-Za-z0-9+%20]+)";
            Regex regex = new Regex(pattern);
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

                    MatchCollection matches = regex.Matches(input);
                    foreach (var item in matches)
                    {
                        string[] data = item.ToString().Split('=');

                        string key = data[0].Replace("%20"," ").Replace("+"," ").Trim();
                        string value = data[1].Replace("%20", " ").Replace("+", " ").Trim();

                        if (!result.ContainsKey(key))
                        {
                            result.Add(key, new List<string>());
                        }

                        result[key].Add(value);
                    }

                    StringBuilder sb = new StringBuilder();
                    foreach (var item in result)
                    {
                        sb.AppendFormat("{0}=", item.Key);
                        sb.AppendFormat("[{0}]", string.Join(", ", item.Value));
                    }

                    Console.WriteLine(sb);
                }
            }
        }
    }
}