namespace News.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using News.Data;
    using News.Services.Models;

    public class NewsService : INewsService
    {
        private readonly NewsDbContext db;

        public NewsService(NewsDbContext db)
        {
            this.db = db;
        }

        public async Task<News> AddNewsAsync(NewsInfoServiceModel model)
        {
            News news = new News
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = model.PublishDate
            };

            await this.db.News.AddAsync(news);
            await this.db.SaveChangesAsync();

            return news;
        }

        public async Task<IList<NewsInfoServiceModel>> AllAsync()
        {
            var result = await this.db.News
                .ProjectTo<NewsInfoServiceModel>()
                .OrderByDescending(a => a.PublishDate)
                .ToListAsync();

            return result;
        }

        public async Task<News> DeleteNewsAsync(int id)
        {
            var news = await this.db.News.FirstOrDefaultAsync(a => a.Id == id);

            this.db.News.Remove(news);
            await this.db.SaveChangesAsync();

            return news;
        }

        public async Task<News> EditNewsAsync(int id, NewsInfoServiceModel model)
        {
            var news = await this.db.News
                .Where(a => a.Id == id)
                ///.ProjectTo<NewsInfoServiceModel>()
                .FirstOrDefaultAsync();

            news.Title = model.Title;
            news.Content = model.Content;
            news.PublishDate = model.PublishDate;

            this.db.News.Update(news);
            await this.db.SaveChangesAsync();

            return news;
        }

        public async Task<News> SingleNewsAsync(int id)
        {
            var news = await this.db.News
                 .FirstOrDefaultAsync(a => a.Id == id);

            return news;
        }
    }
}