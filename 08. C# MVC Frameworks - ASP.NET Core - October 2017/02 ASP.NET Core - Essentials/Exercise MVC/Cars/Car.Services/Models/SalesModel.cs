namespace Car.Services.Models
{
    public class SalesModel : CarModel
    {
        public string CustomerName { get; set; }

        public decimal Price { get; set; }

        public decimal PriceWithSale { get; set; }
    }
}