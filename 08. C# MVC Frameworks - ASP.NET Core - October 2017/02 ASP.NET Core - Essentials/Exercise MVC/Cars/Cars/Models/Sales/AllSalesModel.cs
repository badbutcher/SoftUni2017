namespace Cars.Models.Sales
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class AllSalesModel
    {
        public IEnumerable<SalesModel> Sales { get; set; }
    }
}