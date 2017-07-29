namespace _006
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            SortedSet<Person> nameSet = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> ageSet = new SortedSet<Person>(new AgeComparator());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Person person = new Person(data[0], int.Parse(data[1]));
                nameSet.Add(person);
                ageSet.Add(person);
            }

            foreach (var item in nameSet)
            {
                Console.WriteLine(item);
            }

            foreach (var item in ageSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}