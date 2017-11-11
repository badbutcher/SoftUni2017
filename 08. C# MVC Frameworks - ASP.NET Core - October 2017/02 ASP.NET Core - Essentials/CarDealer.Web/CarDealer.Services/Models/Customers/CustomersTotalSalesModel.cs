namespace CarDealer.Services.Models.Customers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Services.Models.Sales;

    public class CustomersTotalSalesModel
    {
        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<SaleModel> BoughtCars { get; set; }

        public decimal TotalMoneySpent
        {
            get
            {
                return this.BoughtCars.Sum(c => c.Price * (1 - (decimal)c.Discount)) * (this.IsYoungDriver ? 0.95m : 1);
            }
        }
    }
}