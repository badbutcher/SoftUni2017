namespace Cars.Models.Suppliers
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class AllSuppliersModel
    {
        public IEnumerable<SupplierBasicInfoModel> Suppliers { get; set; }
    }
}