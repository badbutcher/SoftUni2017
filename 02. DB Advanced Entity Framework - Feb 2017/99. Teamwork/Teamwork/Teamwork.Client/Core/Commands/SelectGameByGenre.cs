using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Services;

namespace Teamwork.Client.Core.Commands
{
    public class SelectGameByGenre
    {
        private GameService gameService;

        public SelectGameByGenre(GameService gameService)
        {
            this.gameService = gameService;
        }

        public string Execute(string data)
        {
            string genre = Console.ReadLine();

            var result = gameService.GetGamesByGenre(genre);

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendFormat("Name: {0,-35} | SP: {1,-5} | MP: {2,-5}\n", item.Name, item.IsSingleplayer, item.IsMultiplayer);
            }

            return sb.ToString();
        }
    }
}
