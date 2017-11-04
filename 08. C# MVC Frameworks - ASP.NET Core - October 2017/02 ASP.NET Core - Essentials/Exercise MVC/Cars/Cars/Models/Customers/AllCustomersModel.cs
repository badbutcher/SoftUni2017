namespace Cars.Models.Customers
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderDirection GetOrderDirection { get; set; }
    }
}