namespace _010
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<Person> result = new List<Person>();

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
                    result.Add(new Person
                    {
                        Name = data[0] + " " + data[1],
                        Group = int.Parse(data[2])
                    });
                }
            }

            var sort = result.GroupBy(a => a.Group).OrderBy(c => c.Key);

            foreach (var group in sort)
            {
                Console.WriteLine("{0} - {1}", group.Key, string.Join(", ", group.Select(a => a.Name)));
            }
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Group { get; set; }
    }
}