namespace Cars.Models.Sales
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class AddSaleModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public IEnumerable<CarModel> Cars { get; set; }
    }
}