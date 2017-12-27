namespace News.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using News.Data;
    using News.Services;
    using Xunit;

    public class NewsServiceTest
    {
        public NewsServiceTest()
        {
            Tests.Initialize();
        }

        [Fact]
        public async Task ListAllItemsSuccessfully()
        {
            // Arrange
            var db = this.GetDatabase();
            db.AddRange(this.GetTestData());

            await db.SaveChangesAsync();

            var newsService = new NewsService(db);

            // Act
            var result = await newsService.AllAsync();

            // Assert
            //Assert.IsType<OkObjectResult>(newsService.AllAsync());
            result.Should().HaveCount(7);
        }

        private NewsDbContext GetDatabase()
        {
            DbContextOptions<NewsDbContext> dbOptions = new DbContextOptionsBuilder<NewsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new NewsDbContext(dbOptions);
        }

        private IEnumerable<News> GetTestData()
        {
            return new List<News>()
            {
                new News(){Id = 1, Title = "Title1 asdasdasd", Content= "Content asdasdasdad", PublishDate = DateTime.Now},
                new News(){Id = 2, Title = "Title2 AAAAAA", Content= "Content BBBBBBB", PublishDate = DateTime.Now.AddDays(-10)},
                new News(){Id = 3, Title = "Title3 VVVVVVV", Content= "Content CCCCCCCC", PublishDate = DateTime.Now.AddDays(-34)},
                new News(){Id = 4, Title = "Title4 DDDDDDD", Content= "Content HHHHHHH", PublishDate = DateTime.Now.AddDays(-12)},
                new News(){Id = 5, Title = "Title5 AAAAVVV", Content= "Content HHHCCBBBB", PublishDate = DateTime.Now.AddDays(-83)},
                new News(){Id = 6, Title = "Title6 asdasdWWWvg", Content= "Content AAAA", PublishDate = DateTime.Now.AddDays(-456)},
                new News(){Id = 7, Title = "Title7 HHHHH", Content= "Content UUUUUU", PublishDate = DateTime.Now.AddDays(-25)},
            };
        }
    }
}
