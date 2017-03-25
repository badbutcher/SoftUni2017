using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Data;
using Teamwork.Models;
using Teamwork.Models.Enums;

namespace Teamwork.Services
{
    public class GameService
    {
        public void GreateGame(string name, bool isSingleplayer, bool isMultiplayer, DateTime relaseDate, GameGenre gameGender)
        {
            Game game = new Game
            {
                Name = name,
                IsSingleplayer = isSingleplayer,
                IsMultiplayer = isSingleplayer,
                RelaseDate = relaseDate,
                GameGenre = gameGender
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public bool DoesGameExist(string game)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Games.Any(g => g.Name == game);
                return check;
            }
        }

        public bool DoesTheGameHaveAnDeveloper(string gameName, string developerName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Games
                    .SingleOrDefault(g => g.Name == gameName)
                    .Developers.Any(d => d.Name == developerName);

                return check;
            }
        }

        public void AddGameToDeveloper(string gameName, string developerName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                Game game = context.Games.SingleOrDefault(g => g.Name == gameName);
                Developer developer = context.Developers.SingleOrDefault(d => d.Name == developerName);

                developer.Games.Add(game);
                game.Developers.Add(developer);
                context.SaveChanges();
            }
        }

        //public void AddGameToDeveloper(string[] gameName, string developerName)
        //{
        //    using (TeamworkContext context = new TeamworkContext())
        //    {
        //        foreach (var item in gameName)
        //        {
        //            Game game = context.Games.SingleOrDefault(g => g.Name == item);
        //            Developer developer = context.Developers.SingleOrDefault(d => d.Name == developerName);

        //            developer.Games.Add(game);
        //            game.Developers.Add(developer);
        //        }


        //        context.SaveChanges();

        //    }
        //}

        public bool DoesTheGameHaveAnPublisher(string gameName, string publisherName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Games
                    .SingleOrDefault(g => g.Name == gameName)
                    .Developers.Any(d => d.Name == publisherName);

                return check;
            }
        }

        public void AddGameToPublisher(string gameName, string publisherName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                Game game = context.Games.SingleOrDefault(g => g.Name == gameName);
                Publisher publisher = context.Publishers.SingleOrDefault(d => d.Name == publisherName);

                publisher.Games.Add(game);
                game.Publishers.Add(publisher);
                context.SaveChanges();
            }
        }

        public List<Game> GetGamesByGenre(string genreName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                GameGenre gender = (GameGenre) Enum.Parse(typeof(GameGenre), genreName);

                var result = context.Games

                    .Where(g=>g.GameGenre == gender)
                    .ToList();

                return result.ToList();
            }
        }
    }
}