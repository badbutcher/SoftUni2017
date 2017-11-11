namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using CarDealer.Services.Models.Customers;
    using CarDealer.Services.Models.Enums;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> Ordered(OrderDirection order);

        CustomersTotalSalesModel TotalSalesById(int id);

        void Create(string name, DateTime birthday, bool isYoungDriver);

        CustomerModel ById(int id);

        void Edit(int id, string name, DateTime birthDay, bool isYoungDriver);

        bool Exists(int id);
    }
}