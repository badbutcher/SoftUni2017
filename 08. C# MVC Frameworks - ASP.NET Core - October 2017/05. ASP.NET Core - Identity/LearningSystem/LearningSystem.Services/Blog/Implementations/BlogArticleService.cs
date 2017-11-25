namespace LearningSystem.Services.Blog.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Blog.Models;
    using Microsoft.EntityFrameworkCore;

    public class BlogArticleService : IBlogArticleService
    {
        private readonly LearningSystemDbContext db;

        public BlogArticleService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BlogArticleListingServiceModel>> AllAsync(int page = 1)
        {
            var result = await this.db.Articles
                .OrderByDescending(a => a.PublishDate)
                .Skip((page - 1) * ServiceConstats.BlogArticlesPageSize)
                .Take(ServiceConstats.BlogArticlesPageSize)
                .ProjectTo<BlogArticleListingServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task<BlogArticleDetailsServiceModel> ById(int id)
        {
            var result = await this.db.Articles
                .Where(a => a.Id == id)
                .ProjectTo<BlogArticleDetailsServiceModel>()
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task CreateAsync(string title, string content, string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.Now,
                AuthorId = authorId
            };

            this.db.Add(article);
            await this.db.SaveChangesAsync();
        }

        public async Task<int> TotalAsync()
        {
            var result = await this.db.Articles.CountAsync();

            return result;
        }
    }
}