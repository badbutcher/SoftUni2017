namespace _005
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) > 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            else if (this.Age.CompareTo(other.Age) > 0)
            {
                return this.Age.CompareTo(other.Age);
            }
            else if (this.Town.CompareTo(other.Town) > 0)
            {
                return this.Town.CompareTo(other.Town);
            }

            return 0;
        }
    }
}