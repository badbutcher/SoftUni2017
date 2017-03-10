using BookShopSystem.Data;
using BookShopSystem.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem
{
    class Startup
    {
        static void Main()
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
            BookShopContext context = new BookShopContext();

            var books = context.Books
    .Take(3)
    .ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            context.SaveChanges();
            var booksFromQuery = context.Books
                .Select(b => new
                {
                    Title = b.Title,
                    RelatedBooks = b.RelatedBooks
                }).Take(3); ;
               
            // TODO:
            // Query the first three books to get their names
            // and their related book names
            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.ToString());
                }
            }

        }
    }
}
