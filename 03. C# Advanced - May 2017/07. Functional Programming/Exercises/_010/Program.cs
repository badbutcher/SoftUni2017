namespace _010
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }
                else
                {
                    string[] commands = input.Split(' ');
                    string addOrRemove = commands[0];
                    string commandType = commands[1];
                    string critaria = commands[2];

                    if (addOrRemove == "Remove")
                    {
                        Func<List<string>, string, string, List<string>> remove = RemovePersone;
                        names = remove(names, commandType, critaria);
                    }
                    else if (addOrRemove == "Double")
                    {
                        Func<List<string>, string, string, List<string>> dobule = DoublePeople;
                        names = dobule(names, commandType, critaria);
                    }
                }
            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
        }

        private static List<string> DoublePeople(List<string> people, string commandType, string critaria)
        {
            List<string> result = new List<string>();

            if (commandType == "StartsWith")
            {
                foreach (var item in people)
                {
                    if (item.StartsWith(critaria))
                    {
                        result.Add(item);
                    }
                }
            }
            else if (commandType == "Length")
            {
                foreach (var item in people)
                {
                    if (item.Length == int.Parse(critaria))
                    {
                        result.Add(item);
                    }
                }
            }
            else if (commandType == "EndsWith")
            {
                foreach (var item in people)
                {
                    if (item.EndsWith(critaria))
                    {
                        result.Add(item);
                    }
                }
            }
            result.AddRange(people);
            return result;
        }

        private static List<string> RemovePersone(List<string> people, string commandType, string critaria)
        {
            List<string> result = new List<string>();

            if (commandType == "StartsWith")
            {
                foreach (var item in people)
                {
                    if (!item.StartsWith(critaria))
                    {
                        result.Add(item);
                    }
                }
            }
            else if (commandType == "Length")
            {
                foreach (var item in people)
                {
                    if (item.Length != int.Parse(critaria))
                    {
                        result.Add(item);
                    }
                }
            }
            else if (commandType == "EndsWith")
            {
                foreach (var item in people)
                {
                    if (!item.EndsWith(critaria))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}