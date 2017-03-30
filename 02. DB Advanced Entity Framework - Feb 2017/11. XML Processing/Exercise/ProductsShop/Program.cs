namespace ProductsShop
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Model;


    public class Application
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            ////03
            ////AddUsers(context);
            ////AddProductsBuyerSeller(context);
            ////AddCategories(context);

            ////_04_1(context);
            ////_04_2(context);
            ////_04_3(context);
            ////_04_4(context);
        }

        private static void _04_4(ProductShopContext context)
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

            XDocument document = new XDocument();
            XElement xml = new XElement("users");

            foreach (var item in result)
            {
                xml.SetAttributeValue("count", result.Count());

                XElement user = new XElement("user");
                user.SetAttributeValue("first-name", item.FirstName);
                user.SetAttributeValue("last-name", item.LastName);
                user.SetAttributeValue("age", item.Age);
                xml.Add(user);

                XElement soldProducts = new XElement("sold-products");
                XElement prod = new XElement("product");

                soldProducts.SetAttributeValue("count", item.Product.Count());
                xml.Add(soldProducts);

                foreach (var products in item.Product)
                {
                    prod.SetAttributeValue("name", products.Name);
                    prod.SetAttributeValue("price", products.Price);
                    xml.Add(prod);
                }
            }

            document.Add(xml);
            document.Save("../../_04_4.xml");
        }

        private static void _04_3(ProductShopContext context)
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
                .OrderBy(c => c.ProductsCount)
                .ToList();

            XDocument document = new XDocument();
            XElement xml = new XElement("categories");

            foreach (var item in result)
            {
                XElement categoty = new XElement("categoty");
                categoty.SetAttributeValue("name", item.CategorieName);
                categoty.SetElementValue("products-count", item.ProductsCount);

                foreach (var product in item.Product)
                {
                    categoty.SetElementValue("average-price", product.AvgPrice);
                    categoty.SetElementValue("total-revenue", product.TotalRevenue);
                }

                xml.Add(categoty);
            }

            document.Add(xml);
            document.Save("../../_04_3.xml");
        }

        private static void _04_2(ProductShopContext context)
        {
            var result = context.Users
                .Where(s => s.ProductsSold.Count > 1)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    Product = u.ProductsSold
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                })
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToList();

            XDocument document = new XDocument();
            XElement xml = new XElement("users");

            foreach (var item in result)
            {
                XElement user = new XElement("user");
                user.SetAttributeValue("first-name", item.FirstName);
                user.SetAttributeValue("last-name", item.LastName);

                XElement soldProdcuts = new XElement("sold-products");

                foreach (var product in item.Product)
                {
                    XElement prod = new XElement("product");
                    prod.SetElementValue("name", product.Name);
                    prod.SetElementValue("price", product.Price);
                    soldProdcuts.Add(prod);
                }

                xml.Add(user);
                xml.Add(soldProdcuts);

            }

            document.Add(xml);
            document.Save("../../_04_2.xml");
        }

        private static void _04_1(ProductShopContext context)
        {
            var result = context.Products
                  .Select(s => new
                  {
                      s.Name,
                      s.Price,
                      FullName = s.Buyer.FirstName + " " + s.Buyer.LastName
                  })
                  .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.FullName != null)
                  .OrderBy(o => o.Price);

            XDocument document = new XDocument();
            XElement xml = new XElement("products");

            foreach (var item in result)
            {
                XElement product = new XElement("product");
                product.SetAttributeValue("name", item.Name);
                product.SetAttributeValue("price", item.Price);
                product.SetAttributeValue("buyer", item.FullName);

                xml.Add(product);
            }

            document.Add(xml);
            document.Save("../../_04_1.xml");
        }

        private static void AddCategories(ProductShopContext context)
        {
            XDocument document = XDocument.Load("../../Xmls/categories.xml");
            XElement root = document.Root;
            int countOfProducts = context.Products.Count();
            Random rnd = new Random();

            foreach (var item in root.Elements())
            {
                string name = item.Element("name").Value;

                Category category = new Category()
                {
                    Name = name
                };

                context.Categories.Add(category);
                for (int i = 0; i < countOfProducts; i++)
                {
                    Product product = context.Products.Find(rnd.Next(1, countOfProducts + 1));
                    category.Products.Add(product);
                }
            }

            context.SaveChanges();
        }

        private static void AddProductsBuyerSeller(ProductShopContext context)
        {
            XDocument document = XDocument.Load("../../Xmls/products.xml");
            XElement root = document.Root;
            Random rndItem = new Random();
            Random rndValue = new Random();
            foreach (var item in root.Elements())
            {
                string name = item.Element("name").Value;
                decimal price = decimal.Parse(item.Element("price").Value);

                Product product = new Product()
                {
                    Name = name,
                    Price = price,
                    SelledId = rndItem.Next(1, context.Users.Count() + 1),
                    BuyerId = rndItem.Next(1, context.Users.Count() + 1)
                };

                context.Products.Add(product);
            }

            context.SaveChanges();
        }

        private static void AddUsers(ProductShopContext context)
        {
            XDocument document = XDocument.Load("../../Xmls/users.xml");
            XElement root = document.Root;

            foreach (var item in root.Elements())
            {
                string firstName = item.Attribute("first-name")?.Value;
                string lastName = item.Attribute("last-name")?.Value;
                int age = Convert.ToInt32(item.Attribute("age")?.Value);

                User user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}