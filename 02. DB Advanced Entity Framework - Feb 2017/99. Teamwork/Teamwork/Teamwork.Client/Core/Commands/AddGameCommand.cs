namespace Teamwork.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Models.Enums;
    using Services;

    public class AddGameCommand
    {
        private GameService gameService;

        public AddGameCommand(GameService gameService)
        {
            this.gameService = gameService;
        }

        public string Execute(string data)
        {
            Console.Write("Enter game name: ");
            string name = Console.ReadLine();

            Console.Write("Is the game singleplayer: ");
            string isSingleplayer = Console.ReadLine();

            Console.Write("Is the game multiplayer: ");
            string isMultiplayer = Console.ReadLine();

            Console.Write("When was the game released: ");
            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("What is the game genre: ");
            string gameGenre = Console.ReadLine();

            if (this.gameService.DoesGameExist(name))
            {
                throw new ArgumentException("Game already exist");
            }

            GameGenre genre = (GameGenre)Enum.Parse(typeof(GameGenre), gameGenre);

            this.gameService.GreateGame(name, ToBoolean(isSingleplayer), ToBoolean(isMultiplayer), releaseDate, genre);

            return $"Game {name} was added";
        }

        private static bool ToBoolean(string s)
        {
            string[] trueStrings = { "y", "yes", "Yes", "true" };
            string[] falseStrings = { "n", "no", "No", "false" };

            if (trueStrings.Contains(s, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }

            if (falseStrings.Contains(s, StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            throw new InvalidCastException("only the following are supported for converting strings to boolean: "
                + string.Join(",", trueStrings)
                + " and "
                + string.Join(",", falseStrings));
        }
    }
}