using Newtonsoft.Json;
using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ProductsShop
{
    class Startup
    {
        static void Main()
        {
            ShopContext context = new ShopContext();
            ////context.Database.Initialize(true);

            ////02
            ////AddUsers(context);
            ////AddProductsBuyerSeller(context);
            ////AddCategories(context);

            ////_03_1(context);
            ////_03_2(context);
            ////_03_3(context);
            ////_03_4(context);
        }

        private static void _03_4(ShopContext context)
        {
            var result = context.Users
                .Where(s => s.ProductsSold.Count > 1)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    Product = u.ProductsSold
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                })
                .OrderByDescending(s => s.Product.Count())
                .ThenBy(s => s.LastName)
                .ToList();

            var uCount = new
            {
                userCount = result.Count(),
                result = result
            };

            var jsonProduct = JsonConvert.SerializeObject(uCount, Formatting.Indented);

            File.WriteAllText("../../Exports/[3.4].json", jsonProduct);
        }

        private static void _03_3(ShopContext context)
        {
            var result = context.Categories
                .Select(c => new
                {
                    CategorieName = c.Name,
                    ProductsCount = c.Products.Count,
                    Product = c.Products
                    .Select(p => new
                    {
                        AvgPrice = c.Products.Average(a => a.Price),
                        TotalRevenue = c.Products.Sum(m => m.Price)
                    })
                })
                .OrderBy(c => c.CategorieName)
                .ToList();
            var jsonProduct = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[3.3].json", jsonProduct);
        }

        private static void _03_2(ShopContext context)
        {
            var result = context.Users
                .Where(u => u.ProductsSold.Count > 1)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    Product = u.ProductsSold
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        p.Buyer.FirstName,
                        p.Buyer.LastName
                    })
                })
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToList();
            var jsonProduct = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[3.2].json", jsonProduct);
        }

        private static void _03_1(ShopContext context)
        {
            var result = context.Products
                .Select(u => new
                {
                    u.Name,
                    u.Price,
                    Seller = u.Seller.FirstName + " " + u.Seller.LastName
                })
                .Where(s => s.Price >= 500 && s.Price <= 1000)
                .OrderBy(p => p.Price)
                .ToList();
            var jsonProduct = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[3.1].json", jsonProduct);
        }

        private static void AddCategories(ShopContext context)
        {
            var serilizer = new JavaScriptSerializer();
            var jsonString = File.ReadAllText("../../Jsons/categories.json");
            var jsonParce = serilizer.Deserialize<List<Categorie>>(jsonString);
            int countOfProducts = context.Products.Count();
            Random rnd = new Random();
            foreach (var category in jsonParce)
            {
                for (int i = 0; i < countOfProducts; i++)
                {
                    Product product = context.Products.Find(rnd.Next(1, countOfProducts + 1));
                    category.Products.Add(product);
                }
            }

            context.Categories.AddRange(jsonParce);
            context.SaveChanges();
        }

        private static void AddProductsBuyerSeller(ShopContext context)
        {
            var serilizer = new JavaScriptSerializer();
            var jsonString = File.ReadAllText("../../Jsons/products.json");
            var jsonParce = serilizer.Deserialize<List<Product>>(jsonString);
            Random rndItem = new Random();
            Random rndValue = new Random();
            foreach (var item in jsonParce)
            {
                item.SellerId = rndItem.Next(1, context.Users.Count() + 1);
                var value = rndValue.Next(1, 10);
                if (value < 8)
                {
                    item.BuyerId = rndItem.Next(1, context.Users.Count() + 1);
                }
            }

            context.Products.AddRange(jsonParce);
            context.SaveChanges();
        }

        private static void AddUsers(ShopContext context)
        {
            var serilizer = new JavaScriptSerializer();
            var jsonString = File.ReadAllText("../../Jsons/users.json");
            var jsonParce = serilizer.Deserialize<List<User>>(jsonString);
            context.Users.AddRange(jsonParce);
            context.SaveChanges();
        }
    }
}
