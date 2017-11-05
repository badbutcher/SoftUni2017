namespace Car.Services
{
    using System;
    using System.Collections.Generic;
    using Car.Services.Models;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderCustomers(OrderDirection order);

        CustomerCars CustomerCars(int id);

        void Add(string name, DateTime birthdate);

        void Edit(string oldName, string newName, DateTime birthdate);
    }
}