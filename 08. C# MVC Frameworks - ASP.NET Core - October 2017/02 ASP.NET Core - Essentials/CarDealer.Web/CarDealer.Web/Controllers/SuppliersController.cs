namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Web.Models.Suppliers;
    using Microsoft.AspNetCore.Mvc;

    public class SuppliersController : Controller
    {
        private const string SuppliersView = "Suppliers";

        private readonly ISupplierService supplier;

        public SuppliersController(ISupplierService supplier)
        {
            this.supplier = supplier;
        }

        public IActionResult Local()
        {
            return this.View(SuppliersView, this.GetSupplierModel(false));
        }

        public IActionResult Importers()
        {
            return this.View(SuppliersView, this.GetSupplierModel(true));
        }

        private SuppliersModel GetSupplierModel(bool importers)
        {
            var type = importers ? "Importer" : "Local";

            var suppliers = this.supplier.AllListings(importers);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }
    }
}