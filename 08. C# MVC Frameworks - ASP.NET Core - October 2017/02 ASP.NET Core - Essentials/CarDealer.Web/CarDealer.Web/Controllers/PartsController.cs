namespace CarDealer.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Services;
    using CarDealer.Web.Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PartsController : Controller
    {
        private const int PageSize = 25;

        private readonly IPartService parts;
        private readonly ISupplierService suppliers;

        public PartsController(IPartService parts, ISupplierService suppliers)
        {
            this.parts = parts;
            this.suppliers = suppliers;
        }

        public IActionResult All(int page = 1)
        {
            var parts = this.parts.AllListings(page, PageSize);

            return this.View(new PartPageListingModel
            {
                Parts = parts,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.parts.Total() / (double)PageSize)
            });
        }

        public IActionResult Create()
        {
            return this.View(new PartFormModel
            {
                Suppliers = this.GetSupplierListItems()
            });
        }

        [HttpPost]
        public IActionResult Create(PartFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Suppliers = this.GetSupplierListItems();
                return this.View(model);
            }

            this.parts.Create(model.Name, model.Price, model.Quantity, model.SupplierId);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Delete(int id)
        {
            return this.View(id);
        }

        public IActionResult Destory(int id)
        {
            this.parts.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int id)
        {
            var part = this.parts.ById(id);

            if (part == null)
            {
                return this.NotFound();
            }

            return this.View(new PartFormModel
            {
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity,
                IsEdit = true
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, PartFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.IsEdit = true;
                return this.View(model);
            }

            this.parts.Edit(id, model.Price, model.Quantity);

            return this.RedirectToAction(nameof(this.All));
        }

        private IEnumerable<SelectListItem> GetSupplierListItems()
        {
            return this.suppliers.All()
               .Select(s => new SelectListItem
               {
                   Text = s.Name,
                   Value = s.Id.ToString()
               });
        }
    }
}