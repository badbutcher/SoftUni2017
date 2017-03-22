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
        public void GreateGame(string name, bool isSingleplayer, bool isMultiplayer, DateTime relaseDate, GameGender gameGender)
        {
            Game game = new Game
            {
                Name = name,
                IsSingleplayer = isSingleplayer,
                IsMultiplayer = isSingleplayer,
                RelaseDate = relaseDate,
                GameGender = gameGender
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
    }
}
