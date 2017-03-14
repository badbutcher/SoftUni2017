using BookShop.Data;
using BookShop.Migrations;
using BookShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class Startup
    {
        static void Main(string[] args)
        {
            BookShopContext context = new BookShopContext();
            context.Database.Initialize(true);

            //_001(context);
            //_002(context);
            //_003(context);
            _004(context);
            //_005(context);
            //_006(context);
            //_007(context);
            //_008(context);
            //_009(context);
            //_010(context);

        }

        private static void _010(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        private static void _009(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        private static void _008(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        private static void _007(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        private static void _006(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        private static void _005(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        private static void _004(BookShopContext context)
        {
            throw new NotImplementedException();
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