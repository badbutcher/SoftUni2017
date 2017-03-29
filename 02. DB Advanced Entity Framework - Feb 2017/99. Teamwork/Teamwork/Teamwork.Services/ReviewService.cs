namespace Teamwork.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using Models.Anonymous;

    public class ReviewService
    {
        public void GreateReview(string name, string content, float rating, string gameName)
        {
            Review review = new Review
            {
                Name = name,
                Content = content,
                Rating = rating,
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Reviews.Add(review);
                context.SaveChanges();
            }
        }

        public void AddReviewToGame(string gameName, string reviewTitle)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                Game game = context.Games.SingleOrDefault(g => g.Name == gameName);
                Review review = context.Reviews.SingleOrDefault(r => r.Name == reviewTitle);
                game.Reviews.Add(review);
                context.SaveChanges();
            }
        }

        public bool DoesReviewExist(string reviewTitle)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Reviews.Any(r => r.Name == reviewTitle);
                return check;
            }
        }

        public List<GetGamesByRatingAnonymous> GetGamesByRating(float rating)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var result = context.Reviews
                    .Select(g=> new GetGamesByRatingAnonymous()
                    {
                        GameName = g.Game.Name,
                        ReviewTitle = g.Name,
                        ReviewContnet = g.Content,
                        Rating = g.Rating,
                        
                    })
                    .Where(g => g.Rating >= rating)
                    .OrderBy(r => r.Rating)
                    .ThenBy(r => r.GameName);

                return result.ToList();
            }
        }
    }
}