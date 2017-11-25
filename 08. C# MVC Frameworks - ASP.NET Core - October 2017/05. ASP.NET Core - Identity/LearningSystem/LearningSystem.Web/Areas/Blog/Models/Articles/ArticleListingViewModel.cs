namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using LearningSystem.Services;
    using LearningSystem.Services.Blog.Models;

    public class ArticleListingViewModel
    {
        public IEnumerable<BlogArticleListingServiceModel> Artciles { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / ServiceConstats.BlogArticlesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages
            ? this.TotalPages : this.CurrentPage + 1;
    }
}