namespace CarDealer.Web.Models.Suppliers
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Suppliers;

    public class SuppliersModel
    {
        public string Type { get; set; }

        public IEnumerable<SupplierModel> Suppliers { get; set; }
    }
}