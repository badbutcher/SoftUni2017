namespace Cars.Controllers
{
    using Car.Services;
    using Cars.Models.Suppliers;
    using Microsoft.AspNetCore.Mvc;

    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplier;

        public SuppliersController(ISupplierService supplier)
        {
            this.supplier = supplier;
        }

        [Route("suppliers/{type}")]
        public IActionResult Suppliers(string type)
        {
            var suppliers = this.supplier.Supplier(type);

            return View(new SuppliersTypeModel
            {
                Suppliers = suppliers
            });
        }
    }
}