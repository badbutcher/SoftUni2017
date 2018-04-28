namespace _011
{
    using System.Collections.Generic;

    public class Trainer
    {
        public Trainer(string name, long badges, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.Badges = badges;
            this.Pokemons = pokemons;
        }

        public string Name { get; set; }

        public long Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}