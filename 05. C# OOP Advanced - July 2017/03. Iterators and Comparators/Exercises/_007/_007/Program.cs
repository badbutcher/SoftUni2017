namespace _007
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            SortedSet<Person> listOfSortedPeople = new SortedSet<Person>();
            HashSet<Person> listOfHashedPeople = new HashSet<Person>();
            int countPeople = int.Parse(Console.ReadLine());

            for (var i = 0; i < countPeople; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                listOfHashedPeople.Add(person);
                listOfSortedPeople.Add(person);
            }

            Console.WriteLine(listOfHashedPeople.Count);
            Console.WriteLine(listOfSortedPeople.Count);
        }
    }
}