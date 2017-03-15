namespace BookShop
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Models;
    using Models.Enums;
    using EntityFramework.Extensions;   

    class Startup
    {
        static void Main()
        {
            BookShopContext context = new BookShopContext();
            context.Database.Initialize(true);

            ////_001(context);
            ////_002(context);
            ////_003(context);
            ////_004(context);
            ////_005(context);
            ////_006(context);
            ////_007(context);
            ////_008(context);
            ////_009(context);
            ////_010(context);
            ////_011(context);
            ////_012(context);
            ////_013(context);
            ////_014(context);
            ////_015(context);
            ////_016(context);
        }

        private static void _016(BookShopContext context)
        {
            string[] input = Console.ReadLine().Split();

            var count = context.Database
                .SqlQuery<int>("EXEC dbo.pro_ReturnBooks {0},{1}", input[0], input[1])
                .First();

            Console.WriteLine("{0} {1} has written {2} books", input[0], input[1], count);
        }

        private static void _015(BookShopContext context)
        {
            int numberOfDeletes = context.Books
                .Where(c => c.Copies < 4200)
                .Delete();

            Console.WriteLine(numberOfDeletes + " books were deleted");
        }

        private static void _014(BookShopContext context)
        {
            DateTime date = DateTime.ParseExact("06 06 2013", "dd MM yyyy", null);

            int numberOfUpdates = context.Books
                .Where(c => c.RelaseDate > date)
                .Update(c => new Book() { Copies = c.Copies + 44 });

            Console.WriteLine($"{numberOfUpdates} books are released after 6 Jun 2013 so total of {numberOfUpdates * 44} book copies were added");
        }

        private static void _013(BookShopContext context)
        {
            var resultCategories = context.Categorys
                .Where(c => c.Books.Count > 35)
                .Select(c => new
                {
                    Category = c.Name,
                    Count = c.Books.Count,
                    Books = c.Books
                    .OrderByDescending(r => r.RelaseDate)
                    .ThenBy(t => t.Title)
                    .Select(b => new
                    {
                        Title = b.Title,
                        RelaseDate = b.RelaseDate
                    })
                    .Take(3)
                })
            .OrderByDescending(c => c.Count);

            foreach (var category in resultCategories)
            {
                Console.WriteLine("--{0}: {1} books", category.Category, category.Count);

                foreach (var book in category.Books)
                {
                    Console.WriteLine("{0} ({1})", book.Title, book.RelaseDate.Value.Year);
                }
            }
        }

        private static void _012(BookShopContext context)
        {
            var result = context.Categorys
                .GroupBy(b => new
                {
                    Category = b.Name,
                    Sum = b.Books.Sum(s => s.Copies * s.Price)
                })
                .OrderByDescending(s => s.Key.Sum);

            foreach (var item in result)
            {
                Console.WriteLine("{0} - ${1}", item.Key.Category, item.Key.Sum);
            }
        }

        private static void _011(BookShopContext context)
        {
            var result = context.Authors
                .GroupBy(b => new
                {
                    Copies = b.Books.Sum(s => s.Copies),
                    Author = b.FirstName + " " + b.LastName
                })
                .OrderByDescending(c => c.Key.Copies);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key.Author} - {item.Key.Copies}");
            }
        }

        private static void _010(BookShopContext context)
        {
            int input = int.Parse(Console.ReadLine());

            var result = context.Books
                .Select(b => new
                {
                    Title = b.Title
                })
                .Where(t => t.Title.Length > input)
                .Count();

            Console.WriteLine(result);
        }

        private static void _009(BookShopContext context)
        {
            string input = Console.ReadLine();

            var result = context.Books
                .Select(b => new
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author
                })
                .Where(a => a.Author.LastName.StartsWith(input))
                .OrderBy(a => a.Id);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Title} ({item.Author.FirstName} {item.Author.LastName})");
            }
        }

        private static void _008(BookShopContext context)
        {
            string input = Console.ReadLine();

            var result = context.Books
                .Select(b => new
                {
                    Title = b.Title
                })
                .Where(b => b.Title.Contains(input));

            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }

        private static void _007(BookShopContext context)
        {
            string input = Console.ReadLine();

            var result = context.Books
                .Select(b => new
                {
                    Author = b.Author
                })
                .Distinct()
                .Where(a => a.Author.FirstName.EndsWith(input));

            foreach (var item in result)
            {
                Console.WriteLine(item.Author.FirstName + " " + item.Author.LastName);
            }
        }

        private static void _006(BookShopContext context)
        {
            string input = Console.ReadLine();
            DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", null);

            var result = context.Books
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price,
                    RelaseDate = b.RelaseDate
                })
                .Where(r => r.RelaseDate.Value < date);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Title} - {item.EditionType} - {item.Price}");
            }
        }

        private static void _005(BookShopContext context)
        {
            string[] input = Console.ReadLine().Split();

            var result = context.Books
                .Select(b => new
                {
                    Id = b.Id,
                    Title = b.Title,
                    Categories = b.Categorys
                })
                .Where(c => c.Categories.Any() == input.Any())
                .OrderBy(c => c.Id);

            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }

            ////OR

            ////string[] input = Console.ReadLine().Split();

            ////foreach (var item in context.Books)
            ////{
            ////    if (item.Categorys.Any(c=> input.Contains(c.Name.ToLower())))
            ////    {
            ////        Console.WriteLine(item.Title);
            ////    }
            ////}
        }

        private static void _004(BookShopContext context)
        {
            int input = int.Parse(Console.ReadLine());

            var result = context.Books
                .Select(b => new
                {
                    Id = b.Id,
                    Title = b.Title,
                    Date = b.RelaseDate
                })
                .Where(d => d.Date.Value.Year != input)
                .OrderBy(b => b.Id);

            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }

        private static void _003(BookShopContext context)
        {
            var result = context.Books
                .Select(b => new
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price
                })
                .Where(b => b.Price < 5 || b.Price > 40)
                .OrderBy(b => b.Id);

            foreach (var item in result)
            {
                Console.WriteLine("{0} = ${1:F2}", item.Title, item.Price);
            }
        }

        private static void _002(BookShopContext context)
        {
            var result = context.Books
                .Select(b => new
                {
                    Id = b.Id,
                    Title = b.Title,
                    Type = b.EditionType,
                    Copies = b.Copies
                })
                .Where(b => b.Type == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.Id);

            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }

        private static void _001(BookShopContext context)
        {
            string input = Console.ReadLine().ToLower();

            var result = context.Books
                .Select(b => new
                {
                    Title = b.Title,
                    Age = b.AgeRestriction
                })
                .Where(b => b.Age.ToString().ToLower() == input)
                .Select(t => new
                {
                    Title = t.Title
                });

            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}