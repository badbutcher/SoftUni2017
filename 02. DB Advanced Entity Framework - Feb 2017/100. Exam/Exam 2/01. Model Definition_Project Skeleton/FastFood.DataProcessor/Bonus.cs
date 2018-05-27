namespace FastFood.DataProcessor
{
    using FastFood.Data;
    using FastFood.Models;
    using System.Linq;

    public static class Bonus
    {
        public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
        {
            Item item = context.Items.FirstOrDefault(a => a.Name == itemName);

            if (item == null)
            {
                return $"Item {itemName} not found!";
            }
            else
            {
                decimal oldPrice = item.Price;
                item.Price = newPrice;
                context.SaveChanges();
                return $"{itemName} Price updated from ${oldPrice:F2} to ${newPrice:F2}";
            }
        }
    }
}