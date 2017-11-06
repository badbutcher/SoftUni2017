namespace Car.Services
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public interface ISupplierService
    {
        IEnumerable<SupplierModel> Supplier(string type);

        IEnumerable<SuppliersNameModel> GetSuppliers();

        void Add(string name, bool isImporter);

        IEnumerable<SupplierBasicInfoModel> All();

        void Edit(string oldName, string newName, bool isImporter);

        SupplierBasicInfoModel GetSupplier(string name);

        void Delete(string name);
    }
}