namespace BookShop.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Contracts;
    using BookShop.Services.Models;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public AuthorBooksServiceModel AuthorById(int id)
        {
            var result = this.db.Authors
                .ProjectTo<AuthorBooksServiceModel>()
                .FirstOrDefault(a => a.Id == id);

            return result;
        }

        public List<FullBookInfoServiceModel> BooksByAuthorId(int id)
        {
            var result = this.db.Books
                .Where(a => a.AuthorId == id)
                .ProjectTo<FullBookInfoServiceModel>()
                .ToList();

            return result;
        }

        public void CreateAuthor(CreateAuthorServiceModel model)
        {
            var author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            this.db.Authors.Add(author);
            this.db.SaveChanges();
        }
    }
}