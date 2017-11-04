namespace Car.Services
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderCustomers(OrderDirection order);

        CustomerCars CustomerCars(int id);
    }
}