using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Models.Enums;
using Teamwork.Services;

namespace Teamwork.Client.Core.Commands
{
    public class AddGameCommand
    {
        private GameService gameService;

        public AddGameCommand(GameService gameService)
        {
            this.gameService = gameService;
        }

        public string Execute(string data)
        {

            string name = Console.ReadLine();
            string isSingleplayer = Console.ReadLine();
            bool isMultiplayer = bool.Parse(Console.ReadLine());
            DateTime relaseDate = DateTime.Parse(Console.ReadLine());
            string gameGender = Console.ReadLine();

            if (gameService.DoesGameExist(name))
            {
                throw new ArgumentException("Game does exist");
            }

            GameGender gender;
            bool isGenderValid = Enum.TryParse(gameGender, out gender);
            this.gameService.GreateGame(name, ToBoolean(isSingleplayer), isMultiplayer, relaseDate, gender);

            return "asd";
        }

        private static bool ToBoolean(string s)
        {
            string[] trueStrings = { "1", "y", "yes", "true" };
            string[] falseStrings = { "0", "n", "no", "false" };


            if (trueStrings.Contains(s, StringComparer.OrdinalIgnoreCase))
                return true;
            if (falseStrings.Contains(s, StringComparer.OrdinalIgnoreCase))
                return false;

            throw new InvalidCastException("only the following are supported for converting strings to boolean: "
                + string.Join(",", trueStrings)
                + " and "
                + string.Join(",", falseStrings));
        }
    }

}


//public string Execute(string[] data)
//{

//    string name = data[0];
//    bool isSingleplayer = bool.Parse(data[1]);
//    bool isMultiplayer = bool.Parse(data[2]);
//    DateTime relaseDate = DateTime.Parse(data[3]);
//    string gameGender = data[4];

//    if (gameService.DoesGameExist(name))
//    {
//        throw new ArgumentException("Game does exist");
//    }

//    GameGender gender;
//    bool isGenderValid = Enum.TryParse(gameGender, out gender);
//    this.gameService.GreateGame(name, isSingleplayer, isMultiplayer, relaseDate, gender);

//    return "asd";
//}