﻿namespace Cars.Models.Suppliers
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class SuppliersTypeModel
    {
        public IEnumerable<SupplierModel> Suppliers { get; set; }
    }
}