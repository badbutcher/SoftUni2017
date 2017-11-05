namespace Cars.Models.Suppliers
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class ListOfSuppliers
    {
        public IEnumerable<SuppliersNameModel> Suppliers { get; set; }
    }
}