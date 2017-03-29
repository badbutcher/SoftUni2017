namespace Teamwork.Client.Core
{
    using Commands;
    using Services;

    public class CommandDispatcher
    {
        public string DispatchCommand(string commandParameters)
        {
            GameService gameService = new GameService();
            DeveloperService developerService = new DeveloperService();
            PublisherService publisherService = new PublisherService();
            ReviewService reviewService = new ReviewService();
            CommentService commentService = new CommentService();

            string result = string.Empty;

            switch (commandParameters)
            {
                case "AddGame":
                    AddGameCommand addGame = new AddGameCommand(gameService);
                    result = addGame.Execute(commandParameters);
                    break;
                case "AddDeveloper":
                    AddDeveloperCommand addDeveloper = new AddDeveloperCommand(developerService);
                    result = addDeveloper.Execute(commandParameters);
                    break;
                case "AddGameToDeveloper":
                    AddGameToDeveloperCommand addGameToDeveloper = new AddGameToDeveloperCommand(gameService, developerService);
                    result = addGameToDeveloper.Execute(commandParameters);
                    break;
                case "AddPublisher":
                    AddPublisherCommand addPublisher = new AddPublisherCommand(publisherService);
                    result = addPublisher.Execute(commandParameters);
                    break;
                case "AddGameToPublisher":
                    AddGameToPublisherCommand addGameToPublisher = new AddGameToPublisherCommand(gameService, publisherService);
                    result = addGameToPublisher.Execute(commandParameters);
                    break;
                case "AddReview":
                    AddReviewToGameCommand addReviewCommand = new AddReviewToGameCommand(reviewService, gameService);
                    result = addReviewCommand.Execute(commandParameters);
                    break;
                case "AddComment":
                    AddCommentToReviewCommand addCommentCommand = new AddCommentToReviewCommand(commentService, reviewService);
                    result = addCommentCommand.Execute(commandParameters);
                    break;
                case "SelectGameByGenre":
                    SelectGameByGenre selectGameByGenre = new SelectGameByGenre(gameService);
                    result = selectGameByGenre.Execute(commandParameters);
                    break;
                case "Rating":
                    SelectGameReviewRating selectGameByRating = new SelectGameReviewRating(reviewService);
                    result = selectGameByRating.Execute(commandParameters);
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}