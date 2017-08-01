namespace _007
{
    using System;
    using System.Linq;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age - other.Age;
            }

            return result;
        }

        public override bool Equals(object other)
        {
            var p = other as Person;
            return this.Name == p.Name && this.Age == p.Age;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Name.Length * 10000;
            hashCode = this.Name.Aggregate(hashCode, (c, l) => c + l);

            hashCode += this.Age * 10000;

            return hashCode;
        }
    }
}