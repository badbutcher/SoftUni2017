namespace BookShop.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Contracts;
    using BookShop.Services.Models;

    public class BookService : IBookService
    {
        private readonly BookShopDbContext db;

        public BookService(BookShopDbContext db)
        {
            this.db = db;
        }

        public void AddNewBook(FullBookInfoServiceModel model)
        {
            var book = new Book
            {
                AuthorId = model.AuthorId,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                Copies = model.Copies,
                Edition = model.Edition,
                ////Categories = model.BooksCategory
            };

            this.db.Books.Add(book);
            this.db.SaveChanges();
        }

        public BookDataServiceModel BookDataById(int id)
        {
            var result = this.db.Books
                .Where(a => a.Id == id)
                .ProjectTo<BookDataServiceModel>()
                .FirstOrDefault();

            return result;
        }

        public void DeleteBookById(int id)
        {
            var book = this.db.Books
                .FirstOrDefault(a => a.Id == id);

            this.db.Remove(book);
            this.db.SaveChanges();
        }

        public void EditBookById(int id, EditBookServiceModel model)
        {
            var book = this.db.Books
                .Where(a => a.Id == id)
                .ProjectTo<EditBookServiceModel>()
                .FirstOrDefault();

            book.Title = model.Title;
            book.Description = model.Description;
            book.Price = model.Price;
            book.Copies = model.Copies;
            book.Edition = model.Edition;
            book.AuthorId = model.AuthorId;

            this.db.SaveChanges();
        }

        public List<BasicBookInfoServiceModel> TopBooksBySubstring(string text)
        {
            var result = this.db.Books
                .Where(a => a.Title.Contains(text))
                .OrderBy(a => a.Title)
                .Take(10)
                .ProjectTo<BasicBookInfoServiceModel>()
                .ToList();

            return result;
        }
    }
}