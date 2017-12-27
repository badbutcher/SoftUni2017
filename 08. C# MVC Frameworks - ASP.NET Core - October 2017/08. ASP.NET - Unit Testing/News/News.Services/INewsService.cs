namespace News.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using News.Data;
    using News.Services.Models;

    public interface INewsService
    {
        Task<IList<NewsInfoServiceModel>> AllAsync();

        Task<News> AddNewsAsync(NewsInfoServiceModel model);

        Task<News> EditNewsAsync(int id, NewsInfoServiceModel model);

        Task<News> DeleteNewsAsync(int id);

        Task<News> SingleNewsAsync(int id);
    }
}