namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddGameToPublisherCommand
    {
        private GameService gameService;
        private PublisherService publisherService;

        public AddGameToPublisherCommand(GameService gameService, PublisherService publisherService)
        {
            this.gameService = gameService;
            this.publisherService = publisherService;
        }

        public string Execute(string data)
        {
            Console.Write("Enter game name: ");
            string gameName = Console.ReadLine();

            Console.Write("Enter publisher name: ");
            string publisherName = Console.ReadLine();

            if (!this.gameService.DoesGameExist(gameName))
            {
                throw new ArgumentException("Game does not exist");
            }

            if (!this.publisherService.DoesPublisherExist(publisherName))
            {
                throw new ArgumentException("Developer does not exist");
            }

            if (this.gameService.DoesTheGameHaveAnPublisher(gameName, publisherName))
            {
                throw new ArgumentException($"{gameName} is already made by {publisherName}");
            }

            this.gameService.AddGameToPublisher(gameName, publisherName);

            return $"{publisherName} now publishes the game {gameName}";
        }
    }
}