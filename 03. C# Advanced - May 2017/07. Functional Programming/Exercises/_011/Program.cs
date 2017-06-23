namespace _011
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string> people = Console.ReadLine().Split().ToList();
            List<string> peopleToRemove = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Print")
                {
                    break;
                }
                else
                {
                    string[] commands = input.Split(';');
                    string addOrRemove = commands[0];
                    string commandType = commands[1];
                    string critaria = commands[2];

                    if (addOrRemove == "Remove filter")
                    {
                        Func<List<string>, string, string, List<string>> remove = RemovePersone;
                        var res = (remove(people, commandType, critaria));

                        foreach (var item in res)
                        {
                            peopleToRemove.Remove(item);
                        }
                    }
                    else if (addOrRemove == "Add filter")
                    {
                        Func<List<string>, string, string, List<string>> add = AddPeople;
                        peopleToRemove.AddRange(add(people, commandType, critaria));
                    }
                }
            }

            foreach (var item in peopleToRemove)
            {
                people.Remove(item);
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static List<string> AddPeople(List<string> people, string commandType, string critaria)
        {
            List<string> result = new List<string>();

            if (commandType == "Starts with")
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
            else if (commandType == "Ends with")
            {
                foreach (var item in people)
                {
                    if (item.EndsWith(critaria))
                    {
                        result.Add(item);
                    }
                }
            }
            else if (commandType == "Contains")
            {
                foreach (var item in people)
                {
                    if (item.Contains(critaria))
                    {
                        result.Add(item);
                    }
                }
            }

            ///result.AddRange(result);
            return result;
        }

        private static List<string> RemovePersone(List<string> people, string commandType, string critaria)
        {
            List<string> result = new List<string>();

            if (commandType == "Starts with")
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
            else if (commandType == "Ends with")
            {
                foreach (var item in people)
                {
                    if (item.EndsWith(critaria))
                    {
                        result.Add(item);
                    }
                }
            }
            else if (commandType == "Contains")
            {
                foreach (var item in people)
                {
                    if (item.Contains(critaria))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}