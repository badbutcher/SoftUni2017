namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddReviewToGameCommand
    {
        private GameService gameService;
        private ReviewService reviewService;

        public AddReviewToGameCommand(ReviewService reviewService, GameService gameService)
        {
            this.reviewService = reviewService;
            this.gameService = gameService;
        }

        public string Execute(string data)
        {
            Console.Write("Enter review title : ");
            string title = Console.ReadLine();

            Console.Write("Enter contnet : ");
            string content = Console.ReadLine();

            Console.Write("Enter rating (1-10) : ");
            float rating = float.Parse(Console.ReadLine());

            Console.Write("Enter game name for the review : ");
            string gameName = Console.ReadLine();

            if (!this.gameService.DoesGameExist(gameName))
            {
                throw new ArgumentException($"The game {gameName} does not exist");
            }

            this.reviewService.GreateReview(title, content, rating, gameName);

            this.reviewService.AddReviewToGame(gameName, title);

            return "asd";
        }
    }
}