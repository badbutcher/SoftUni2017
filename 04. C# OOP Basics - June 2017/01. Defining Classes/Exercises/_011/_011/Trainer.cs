namespace _011
{
    using System.Collections.Generic;

    public class Trainer
    {
        private string name;
        private long badges;
        private List<Pokemon> pokemons;

        public Trainer(string name, long badges, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.Badges = badges;
            this.Pokemons = pokemons;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public long Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }
    }
}