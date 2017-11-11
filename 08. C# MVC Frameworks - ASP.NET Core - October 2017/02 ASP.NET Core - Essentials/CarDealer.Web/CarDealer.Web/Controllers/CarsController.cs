namespace CarDealer.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Services;
    using CarDealer.Web.Models.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPartService parts;

        public CarsController(ICarService cars, IPartService parts)
        {
            this.cars = cars;
            this.parts = parts;
        }

        [Route("{make}")]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return this.View(new CarsByMakeModel
            {
                Make = make,
                Cars = cars
            });
        }

        [Route("parts")]
        public IActionResult Parts()
        {
            return this.View(this.cars.WithParts());
        }

        [Authorize]
        [Route(nameof(Create))]
        public IActionResult Create()
        {
            return this.View(new CarFormModel
            {
                AllParts = this.GetPartsSelectItems()
            });
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public IActionResult Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                carModel.AllParts = this.GetPartsSelectItems();
                return this.View(carModel);
            }

            this.cars.Create(carModel.Make, carModel.Model, carModel.TravelledDistance, carModel.SelectedParts);

            return this.RedirectToAction(nameof(this.Parts));
        }

        private IEnumerable<SelectListItem> GetPartsSelectItems()
        {
            var result = this.parts.All()
                .Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                });

            return result;
        }
    }
}