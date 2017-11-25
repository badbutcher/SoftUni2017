namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using System.ComponentModel.DataAnnotations;
    using LearningSystem.Data;

    public class PublishArticleFormModel
    {
        [Required]
        [MinLength(DataConstants.ArticleTitleMinLenght)]
        [MaxLength(DataConstants.ArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}