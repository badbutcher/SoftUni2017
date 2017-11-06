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

        [Route("suppliers/all")]
        public IActionResult All()
        {
            if (User.Identity.IsAuthenticated)
            {
                var suppliers = this.supplier.All();

                return View(new AllSuppliersModel
                {
                    Suppliers = suppliers
                });
            }
            else
            {
                return Redirect("/account/login");
            }
        }

        [Route("suppliers/add")]
        public IActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.View();
            }
            else
            {
                return Redirect("/account/login");
            }
        }

        [HttpPost]
        [Route("suppliers/add")]
        public IActionResult Add(string name, bool IsImporter)
        {
            if (User.Identity.IsAuthenticated)
            {
                this.supplier.Add(name, IsImporter);

                return this.Redirect("/suppliers/all");
            }
            else
            {
                return Redirect("/account/login");
            }
        }

        [Route("suppliers/edit/{name}/{importer}")]
        public IActionResult Edit(string name, bool importer)
        {
            if (User.Identity.IsAuthenticated)
            {
                var supplier = this.supplier.GetSupplier(name);

                return this.View(new SingleSupplierModel
                {
                    NewName = name,
                    IsImporter = importer
                });
            }
            else
            {
                return Redirect("/account/login");
            }
        }

        [HttpPost]
        [Route("suppliers/edit/{name}/{importer}")]
        public IActionResult Edit(string name, bool importer, SingleSupplierModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                this.supplier.Edit(name, model.NewName, model.IsImporter);

                return this.Redirect("/suppliers/all");
            }
            else
            {
                return Redirect("/account/login");
            }
        }

        [Route("suppliers/delete/{name}/{importer}")]
        public IActionResult SupplierToDelete(string name, bool importer)
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.View(new SingleSupplierModel
                {
                    NewName = name,
                    IsImporter = importer
                });
            }
            else
            {
                return Redirect("/account/login");
            }
        }

        [HttpPost]
        [Route("suppliers/delete/{name}/{importer}")]
        public IActionResult Delete(string name)
        {
            if (User.Identity.IsAuthenticated)
            {
                this.supplier.Delete(name);

                return this.Redirect("/suppliers/all");
            }
            else
            {
                return Redirect("/account/login");
            }
        }
    }
}