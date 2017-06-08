namespace _013
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<char, char> chars = new Dictionary<char, char>();

            string[] input = Console.ReadLine().Split();
            string one = input[0];
            string two = input[1];

            int min = Math.Min(input[0].Length, input[1].Length);
            bool isExchangeable = true;

            for (int i = 0; i < min; i++)
            {
                if (!chars.ContainsKey(one[i]))
                {
                    if (!chars.ContainsValue(two[i]))
                    {
                        chars.Add(one[i], two[i]);
                    }
                    else
                    {
                        isExchangeable = false;
                        break;
                    }
                }
                else
                {
                    if (chars[one[i]] != two[i])
                    {
                        isExchangeable = false;
                        break;
                    }
                }
            }

            string result = string.Empty;

            if (one.Length > two.Length)
            {
                result = one.Substring(min);
            }
            else
            {
                result = two.Substring(min);
            }

            foreach (char chara in result)
            {
                if (!chars.ContainsValue(chara) && !chars.ContainsKey(chara))
                {
                    isExchangeable = false;
                    break;
                }
            }

            Console.WriteLine(isExchangeable.ToString().ToLower());
        }
    }
}