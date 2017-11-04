using System.Collections.Generic;
using Car.Services.Models;

namespace Cars.Models.Suppliers
{
    public class SuppliersTypeModel
    {
        public IEnumerable<SupplierModel> Suppliers { get; set; }
    }
}