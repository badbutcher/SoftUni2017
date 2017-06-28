namespace _004
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                Person person = new Person();
                person.Name = name;
                person.Age = age;
                people.Add(person);
            }

            var filter = people.OrderBy(a => a.Name).Where(c => c.Age > 30);
            foreach (var item in filter)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.Age);
            }
        }
    }
}