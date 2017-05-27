namespace _005
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split('-');

                if (input[0] == "search")
                {
                    break;
                }
                else
                {
                    string name = input[0];
                    string phoneNumber = input[1];

                    if (!phonebook.ContainsKey(name))
                    {
                        phonebook.Add(name, phoneNumber);
                    }
                    else
                    {
                        phonebook[name] = phoneNumber;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }
                else
                {
                    if (phonebook.ContainsKey(input))
                    {
                        Console.WriteLine("{0} -> {1}", input, phonebook[input]);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist.", input);
                    }
                }
            }
        }
    }
}