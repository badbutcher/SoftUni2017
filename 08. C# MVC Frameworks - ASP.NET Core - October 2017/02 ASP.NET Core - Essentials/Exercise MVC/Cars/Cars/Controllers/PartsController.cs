namespace Cars.Controllers
{
    using Car.Services;
    using Cars.Models.Parts;
    using Cars.Models.Suppliers;
    using Microsoft.AspNetCore.Mvc;

    public class PartsController : Controller
    {
        private readonly IPartService parts;
        private readonly ISupplierService suppliers;

        public PartsController(IPartService parts, ISupplierService suppliers)
        {
            this.parts = parts;
            this.suppliers = suppliers;
        }

        [Route("parts/all")]
        public IActionResult All()
        {
            var allParts = parts.AllParts();

            return View(new AllPartsModel
            {
                Parts = allParts
            });
        }

        [Route("parts/add")]
        public IActionResult Add()
        {
            var allSuppliers = suppliers.GetSuppliers();

            return View(new ListOfSuppliers
            {
                Suppliers = allSuppliers
            });
        }

        [HttpPost]
        [Route("parts/add")]
        public IActionResult Add(string name, decimal price, int quantity, string supplier)
        {
            this.parts.AddParts(name, price, quantity, supplier);

            return Redirect("/parts/all");
        }

        [Route("parts/delete/{name}")]
        public IActionResult PartToDelete(string name)
        {
            var part = parts.GetPart(name);

            return this.View(new SinglePartModel
            {
                Part = part
            });
        }

        [HttpPost]
        [Route("parts/delete/{name}")]
        public IActionResult Delete(string name)
        {
            this.parts.DeletePart(name);

            return Redirect("/parts/all");
        }

        [Route("parts/edit/{name}")]
        public IActionResult Edit(string name)
        {
            var part = parts.GetPart(name);

            return View(new SinglePartModel
            {
                Part = part
            });
        }

        [HttpPost]
        [Route("parts/edit/{name}")]
        public IActionResult Edit(string name, decimal price, int quantity)
        {
            this.parts.Edit(name, price, quantity);

            return Redirect("/parts/all");
        }
    }
}