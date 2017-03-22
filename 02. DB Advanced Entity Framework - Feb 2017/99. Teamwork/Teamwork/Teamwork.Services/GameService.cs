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
        public void GreateGame(string name, bool isSingleplayer, bool isMultiplayer, DateTime relaseDate, string gameGender)
        {
            Game game = new Game
            {
                Name = name,
                IsSingleplayer = isSingleplayer,
                IsMultiplayer = isSingleplayer,
                RelaseDate = relaseDate,
                GameGender = (GameGender)int.Parse(gameGender)
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                
            }
        }
    }
}
