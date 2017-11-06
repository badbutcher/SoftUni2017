namespace Cars.Controllers
{
    using Car.Services;
    using Cars.Models.Cars;
    using Cars.Models.Parts;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPartService parts;

        public CarsController(ICarService cars, IPartService parts)
        {
            this.cars = cars;
            this.parts = parts;
        }

        [Route("cars/all")]
        public IActionResult All()
        {
            var cars = this.cars.All();

            return View(new CarsMakeModel
            {
                Cars = cars
            });
        }

        [Route("cars/add")]
        public IActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
            {
                var parts = this.parts.AllParts();

                return View(new AllPartsModel
                {
                    Parts = parts
                });
            }
            else
            {
                return Redirect("/account/login");
            }
        }

        [HttpPost]
        [Route("cars/add")]
        public IActionResult Add(string make, string model, long travelledDistance)
        {
            this.cars.AddCar(make, model, travelledDistance);

            return Redirect("/cars/all");
        }

        [Route("cars/{make}")]
        public IActionResult CarMake(string make)
        {
            var cars = this.cars.CarsFromMake(make);

            return View(new CarsMakeModel
            {
                Cars = cars
            });
        }

        [Route("cars/parts")]
        public IActionResult CarParts()
        {
            var carsParts = this.cars.CarsParts();

            return View(new CarsPartsModel
            {
                CarsParts = carsParts
            });
        }
    }
}