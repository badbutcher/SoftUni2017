namespace _001
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, SortedSet<string>> categories = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, int> students = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();
                    string name = data[0];
                    string category = data[1];
                    int points = int.Parse(data[2]);

                    if (!categories.ContainsKey(name))
                    {
                        categories.Add(name, new SortedSet<string>());
                    }

                    categories[name].Add(category);

                    if (!students.ContainsKey(name))
                    {
                        students.Add(name, points);
                    }
                    else
                    {
                        students[name] += points;
                    }
                }
            }

            var sortStudents = students.OrderByDescending(a => a.Value).ThenBy(b => b.Key);

            foreach (var student in sortStudents)
            {
                var sortCategories = categories[student.Key].OrderBy(a => a);

                Console.WriteLine($"{student.Key}: {student.Value} [{string.Join(", ", sortCategories)}]");
            }
        }
    }
}