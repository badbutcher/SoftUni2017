namespace CarDealer.Web.Models.Customers
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Customers;
    using CarDealer.Services.Models.Enums;

    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderDirection OrderDirection { get; set; }
    }
}