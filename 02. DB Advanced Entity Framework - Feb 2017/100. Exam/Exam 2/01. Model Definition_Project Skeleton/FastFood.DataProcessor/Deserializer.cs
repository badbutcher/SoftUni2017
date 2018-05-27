namespace FastFood.DataProcessor
{
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            EmployeeDto[] data = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Employee> employees = new List<Employee>();

            foreach (var item in data)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Position position = context.Positions.FirstOrDefault(a => a.Name == item.Position);

                if (position == null)
                {
                    Position newPosition = new Position { Name = item.Position };

                    context.Positions.Add(newPosition);
                    context.SaveChanges();

                    position = newPosition;
                }

                Employee employee = new Employee()
                {
                    Name = item.Name,
                    Age = item.Age,
                    Position = position
                };

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            ItemDto[] data = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Item> items = new List<Item>();

            foreach (var item in data)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (items.FirstOrDefault(a => a.Name == item.Name) != null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = context.Categories.FirstOrDefault(a => a.Name == item.Category);

                if (category == null)
                {
                    Category newCategory = new Category { Name = item.Category };

                    context.Categories.Add(newCategory);
                    context.SaveChanges();

                    category = newCategory;
                }

                Item itemToAdd = new Item()
                {
                    Name = item.Name,
                    Price = item.Price,
                    Category = category
                };

                items.Add(itemToAdd);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            XDocument data = XDocument.Parse(xmlString);

            StringBuilder sb = new StringBuilder();
            List<Order> orders = new List<Order>();

            foreach (var item in data.Root.Elements())
            {
                string customerName = item.Element("Customer").Value;
                string employeeName = item.Element("Employee").Value;
                DateTime dateTime = DateTime.ParseExact(item.Element("DateTime").Value, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                OrderType type = Enum.Parse<OrderType>(item.Element("Type").Value);
                XElement orderItems = (item.Element("Items"));

                Employee employee = context.Employees.FirstOrDefault(a => a.Name == employeeName);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Order order = new Order()
                {
                    Customer = customerName,
                    Employee = employee,
                    DateTime = dateTime,
                    Type = type
                };

                List<OrderItem> orderItemsList = new List<OrderItem>();

                foreach (var oi in orderItems.Elements())
                {
                    string itemName = oi.Element("Name").Value;
                    int quntity = int.Parse(oi.Element("Quantity").Value);

                    Item itemtoAdd = context.Items.FirstOrDefault(a => a.Name == itemName);

                    if (itemtoAdd == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }

                    OrderItem orderItem = new OrderItem { Item = itemtoAdd, Quantity = quntity };
                    orderItemsList.Add(orderItem);
                }

                order.OrderItems = orderItemsList;
                if (!IsValid(order))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                orders.Add(order);
                sb.AppendLine(string.Format("Order for {0} on {1} added",
                    customerName,
                    order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}