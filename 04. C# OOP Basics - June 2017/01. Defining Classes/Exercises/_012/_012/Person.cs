namespace _012
{
    using System.Collections.Generic;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Company Company { get; set; }

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public List<Parents> Parents { get; set; } = new List<Parents>();

        public List<Children> Childrens { get; set; } = new List<Children>();

        public Car Car { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}