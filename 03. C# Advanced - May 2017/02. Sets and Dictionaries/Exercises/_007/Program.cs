namespace _007
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }
                else
                {
                    string email = Console.ReadLine();

                    if (!(email.EndsWith("us") || email.EndsWith("uk")))
                    {
                        emails.Add(name, email);
                    }
                }
            }

            foreach (var item in emails)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}