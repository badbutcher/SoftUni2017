namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddCommentToReviewCommand
    {
        private ReviewService reviewService;
        private CommentService commentService;

        public AddCommentToReviewCommand(CommentService commentService, ReviewService reviewService)
        {
            this.commentService = commentService;
            this.reviewService = reviewService;
        }

        public string Execute(string data)
        {
            Console.Write("Enter review title to comment : ");
            string reviewTitle = Console.ReadLine();

            Console.Write("Enter comment contnet : ");
            string commentContent = Console.ReadLine();

            if (!this.reviewService.DoesReviewExist(reviewTitle))
            {
                throw new ArgumentException($"{reviewTitle} does not exist");
            }

            this.commentService.AddComment(commentContent);

            this.commentService.AddCommentToReview(commentContent, reviewTitle);

            return "asd";
        }
    }
}