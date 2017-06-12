namespace _009
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"([^&=?]*)=([^&=]*)";
            string replacePatter = @"((%20|\+)+)";
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
                        string[] data = Regex.Replace(item.ToString(), replacePatter, " ").Split('=');

                        string key = data[0].Trim();
                        string value = data[1].Trim();

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