using FastFood.Data;
namespace FastFood.DataProcessor
{
    using FastFood.DataProcessor.Dto.Export;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var result = context.Orders
                .Where(a => a.Employee.Name == employeeName && a.Type == Enum.Parse<OrderType>(orderType))
                .Select(a => new
                {
                    Customer = a.Customer,
                    Items = a.OrderItems.Select(b => new
                    {
                        Name = b.Item.Name,
                        Price = b.Item.Price,
                        Quantity = b.Quantity
                    }),
                    TotalPrice = a.OrderItems.Sum(b => b.Item.Price * b.Quantity)
                })
                .OrderByDescending(a => a.TotalPrice)
                .ThenByDescending(a => a.Items.Count());

            var output = new
            {
                Name = employeeName,
                Orders = result,
                TotalMade = result.Sum(a => a.TotalPrice)
            };

            string serialized = JsonConvert.SerializeObject(output);

            return serialized;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            string[] categories = categoriesString.Split(',');

            var result = context.Items
                .Where(a => categories.Any(b => b == a.Category.Name))
                .GroupBy(a => a.Category.Name)
                .Select(a => new CategoryDto
                {
                    Name = a.Key,
                    MostPopularItem = a.Select(b => new ItemDto
                    {
                        Name = b.Name,
                        TotalMade = b.OrderItems.Sum(d => d.Item.Price * d.Quantity),
                        TimesSold = b.OrderItems.Sum(d => d.Quantity)
                    })
                    .OrderByDescending(b => b.TotalMade)
                    .ThenByDescending(b => b.TimesSold)
                    .First()
                })
                .OrderByDescending(a => a.MostPopularItem.TotalMade)
                .ThenByDescending(a => a.MostPopularItem.TimesSold);

            XDocument output = new XDocument();
            output.Add(new XElement("Categories"));

            foreach (var c in result)
            {
                XElement category = new XElement("Category");
                category.Add(new XElement("Name", c.Name));

                XElement popItem = new XElement("MostPopularItem");
                popItem.Add(new XElement("Name", c.MostPopularItem.Name));
                popItem.Add(new XElement("TotalMade", c.MostPopularItem.TotalMade));
                popItem.Add(new XElement("TimesSold", c.MostPopularItem.TimesSold));

                category.Add(popItem);
                output.Element("Categories").Add(category);
            }

            return output.ToString();
        }
    }
}