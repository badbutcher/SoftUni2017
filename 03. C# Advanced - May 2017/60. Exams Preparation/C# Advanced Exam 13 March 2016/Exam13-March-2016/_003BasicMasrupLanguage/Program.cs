namespace _003BasicMasrupLanguage
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @".*(inverse|reverse).*""(.*)""|.*(repeat).*""(.*)"".*""(.*)""";
            Regex regex = new Regex(pattern);
            int counter = 1;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "<stop/>")
                {
                    break;
                }
                else
                {
                    Match match = regex.Match(input);
                    if (match.Groups[1].Value == "inverse")
                    {
                        string m = match.Groups[2].Value;
                        if (m.Length == 0)
                        {
                            continue;
                        }

                        string newWord = string.Empty;
                        for (int i = 0; i < m.Length; i++)
                        {
                            if (char.IsUpper(m[i]))
                            {
                                newWord += m[i].ToString().ToLower();
                            }
                            else if (char.IsLower(m[i]))
                            {
                                newWord += m[i].ToString().ToUpper();
                            }
                            else
                            {
                                newWord += m[i];
                            }
                        }

                        Console.WriteLine("{0}. {1}", counter++, newWord);
                    }
                    else if (match.Groups[1].Value == "reverse")
                    {
                        if (match.Groups[2].Value.Length == 0)
                        {
                            continue;
                        }

                        string rev = ReverseString(match.Groups[2].Value);
                        Console.WriteLine("{0}. {1}", counter++, rev);
                    }
                    else if (match.Groups[3].Value == "repeat")
                    {
                        int value = int.Parse(match.Groups[4].Value);
                        if (value == 0)
                        {
                            continue;
                        }

                        for (int i = 0; i < value; i++)
                        {
                            Console.WriteLine("{0}. {1}", counter++, match.Groups[5].Value);
                        }
                    }
                }
            }
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}