namespace Car.Services
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public interface ISupplierService
    {
        IEnumerable<SupplierModel> Supplier(string type);
    }
}