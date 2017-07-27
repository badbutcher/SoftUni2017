namespace _005
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
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
                    Person person = new Person(data[0], int.Parse(data[1]), data[2]);
                    people.Add(person);
                }
            }

            int number = int.Parse(Console.ReadLine());

            if (number >= people.Count)
            {
                Console.WriteLine("No matches");
                return;
            }

            Person personToCompare = people.ElementAt(number);

            var peopleFoundCount = people.Count(a => a.CompareTo(personToCompare) == 0);
            var notEqualsToPersonCount = people.Count - peopleFoundCount;
            Console.WriteLine($"{peopleFoundCount} {notEqualsToPersonCount} {people.Count}");
        }
    }
}