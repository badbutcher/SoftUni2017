namespace _012
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

                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();
                    string name = data[0];

                    if (people.FirstOrDefault(a => a.Name == name) == null)
                    {
                        people.Add(new Person(name));
                    }

                    if (data[1] == "company")
                    {
                        string companyName = data[2];
                        string department = data[3];
                        decimal salary = decimal.Parse(data[4]);

                        Company company = new Company(companyName, department, salary);
                        people.FirstOrDefault(a => a.Name == name).Company = company;
                    }
                    else if (data[1] == "pokemon")
                    {
                        string pokemonName = data[2];
                        string pokemonType = data[3];

                        Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                        people.FirstOrDefault(a => a.Name == name).Pokemons.Add(pokemon);
                    }
                    else if (data[1] == "parents")
                    {
                        string parentName = data[2];
                        string parentBirthday = data[3];

                        Parents parents = new Parents(parentName, parentBirthday);
                        people.FirstOrDefault(a => a.Name == name).Parents.Add(parents);
                    }
                    else if (data[1] == "children")
                    {
                        string childName = data[2];
                        string childBirthday = data[3];

                        Children children = new Children(childName, childBirthday);
                        people.FirstOrDefault(a => a.Name == name).Childrens.Add(children);
                    }
                    else if (data[1] == "car")
                    {
                        string carModel = data[2];
                        int carSpeed = int.Parse(data[3]);

                        Car car = new Car(carModel, carSpeed);
                        people.FirstOrDefault(a => a.Name == name).Car = car;
                    }
                }
            }

            string search = Console.ReadLine();

            Person personToFind = people.FirstOrDefault(a => a.Name == search);

            Console.WriteLine(personToFind.Name.ToString());
            Console.WriteLine("Company:");
            if (personToFind.Company != null)
            {
                Console.WriteLine(personToFind.Company.ToString());
            }

            Console.WriteLine("Car:");
            if (personToFind.Car != null)
            {
                Console.WriteLine(personToFind.Car.ToString());
            }

            Console.WriteLine("Pokemon:");
            foreach (var item in personToFind.Pokemons)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Parents:");
            foreach (var item in personToFind.Parents)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Children:");
            foreach (var item in personToFind.Childrens)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}