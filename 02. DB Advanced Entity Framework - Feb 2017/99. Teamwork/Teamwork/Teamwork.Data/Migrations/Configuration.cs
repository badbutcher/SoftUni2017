namespace Teamwork.Data.Migrations
{
    using Models;
    using Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeamworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeamworkContext context)
        {
            Developer dev1 = new Developer()
            {
                Name = "Valve",
                FoundedInCountryName = "United States",
                DateFounded = DateTime.Parse("24.08.1996")
            };

            Developer dev2 = new Developer()
            {
                Name = "Turtle Rock Studios",
                FoundedInCountryName = "United States",
                DateFounded = DateTime.Parse("01.03.2002")
            };

            Publisher pub1 = new Publisher()
            {
                Name = "Valve",
                FoundedInCountryName = "United States",
                FoundedIn = DateTime.Parse("24.08.1996")
            };

            context.Developers.AddOrUpdate(d => d.Name, dev1, dev2);
            context.Publishers.AddOrUpdate(p => p.Name, pub1);
            context.SaveChanges();

            Developer ValveDev = context.Developers.First(d => d.Name == "Valve");
            Developer TurtleRockStudiosDev = context.Developers.First(d => d.Name == "Turtle Rock Studios");
            Publisher ValvePub = context.Publishers.First(p => p.Name == "Valve");

            context.Games.AddOrUpdate(g => g.Name,
            new Game()
            {
                Name = "Half-Life",
                IsSingleplayer = true,
                IsMultiplayer = false,
                RelaseDate = DateTime.Parse("19.11.1999"),
                GameGenre = GameGenre.FPS,
                Publishers = new List<Publisher>()
                {
                    ValvePub
                },
                Developers = new List<Developer>()
                {
                    ValveDev
                }
            },
            new Game()
            {
                Name = "Portal",
                IsSingleplayer = true,
                IsMultiplayer = false,
                RelaseDate = DateTime.Parse("09.10.2007"),
                GameGenre = GameGenre.FPS,
                Publishers = new List<Publisher>()
                {
                    ValvePub
                },
                Developers = new List<Developer>()
                {
                    ValveDev
                }
            },
            new Game()
            {
                Name = "Left 4 Dead",
                IsSingleplayer = true,
                IsMultiplayer = true,
                RelaseDate = DateTime.Parse("17.11.2008"),
                GameGenre = GameGenre.FPS,
                Publishers = new List<Publisher>()
                {
                    ValvePub
                },
                Developers = new List<Developer>()
                {
                    ValveDev
                },
                Reviews = new List<Review>()
                {

                }
            },
            new Game()
            {
                Name = "Team Fortress 2",
                IsSingleplayer = true,
                IsMultiplayer = true,
                RelaseDate = DateTime.Parse("10.09.2007"),
                GameGenre = GameGenre.FPS,
                Publishers = new List<Publisher>()
                {
                    ValvePub
                },
                  Developers = new List<Developer>()
                {
                    ValveDev
                }
            },
            new Game()
            {
                Name = "Dota 2",
                IsSingleplayer = true,
                IsMultiplayer = true,
                RelaseDate = DateTime.Parse("09.07.2013"),
                GameGenre = GameGenre.MOBA,
                Publishers = new List<Publisher>()
                {
                    ValvePub
                },
                Developers = new List<Developer>()
                {
                    ValveDev
                }
            },
            new Game()
            {
                Name = "Counter-Strike: Source",
                IsSingleplayer = true,
                IsMultiplayer = true,
                RelaseDate = DateTime.Parse("01.11.2004"),
                GameGenre = GameGenre.FPS,
                Publishers = new List<Publisher>()
                {
                    ValvePub
                },
                Developers = new List<Developer>()
                {
                    ValveDev, TurtleRockStudiosDev
                }
            });
        }
    }
}