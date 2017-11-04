using System.Collections.Generic;
using Car.Services.Models;

namespace Cars.Models.Sales
{
    public class AllSalesModel
    {
        public IEnumerable<SalesModel> Sales { get; set; }
    }
}