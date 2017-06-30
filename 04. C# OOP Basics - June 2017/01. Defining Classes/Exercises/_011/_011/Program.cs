namespace _011
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();
                    string name = data[0];
                    string pokemonName = data[1];
                    string pokemonType = data[2];
                    long pokemonHealth = long.Parse(data[3]);
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType, pokemonHealth);

                    if (!trainers.Any(a => a.Name == name))
                    {
                        Trainer trainer = new Trainer(name, 0, new List<Pokemon>());
                        trainer.Pokemons.Add(pokemon);
                        trainers.Add(trainer);
                    }
                    else
                    {
                        trainers.First(a => a.Name == name).Pokemons.Add(pokemon);
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else
                {
                    if (input == "Fire")
                    {
                        CheckPokemons(trainers, input);
                    }
                    else if (input == "Water")
                    {
                        CheckPokemons(trainers, input);
                    }
                    else if (input == "Electricity")
                    {
                        CheckPokemons(trainers, input);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(a => a.Badges))
            {
                Console.WriteLine("{0} {1} {2}", trainer.Name, trainer.Badges, trainer.Pokemons.Count());
            }
        }

        private static void CheckPokemons(List<Trainer> trainers, string input)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(a => a.Element == input))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }

                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }
            }
        }
    }
}