namespace Cars.Controllers
{
    using Car.Services;
    using Cars.Models.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
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