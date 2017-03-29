namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddGameToDeveloperCommand
    {
        private GameService gameService;
        private DeveloperService developerService;

        public AddGameToDeveloperCommand(GameService gameService, DeveloperService developerService)
        {
            this.gameService = gameService;
            this.developerService = developerService;
        }

        public string Execute(string data)
        {
            Console.Write("Enter game name : ");
            string gameName = Console.ReadLine();

            Console.Write("Enter developer name: ");
            string developerName = Console.ReadLine();

            if (!this.gameService.DoesGameExist(gameName))
            {
                throw new ArgumentException("Game does not exist");
            }

            if (!this.developerService.DoesDeveloperExist(developerName))
            {
                throw new ArgumentException("Developer does not exist");
            }

            if (this.gameService.DoesTheGameHaveAnDeveloper(gameName, developerName))
            {
                throw new ArgumentException($"{gameName} is already made by {developerName}");
            }

            this.gameService.AddGameToDeveloper(gameName, developerName);

            return $"{developerName} has made the game {gameName}";
        }
    }
}