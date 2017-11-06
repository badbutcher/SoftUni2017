namespace Cars.Controllers
{
    using Car.Services;
    using Cars.Models.Sales;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : Controller
    {
        private readonly ISaleService sales;
        private readonly ICustomerService customers;
        private readonly ICarService cars;

        public SalesController(ISaleService sales, ICustomerService customers, ICarService cars)
        {
            this.sales = sales;
            this.customers = customers;
            this.cars = cars;
        }

        [Route("sales")]
        public IActionResult AllSales()
        {
            var sales = this.sales.AllSales();

            return View(new AllSalesModel
            {
                Sales = sales
            });
        }

        [Route("sales/{id}")]
        public IActionResult SalesById(int id)
        {
            var sales = this.sales.SaleById(id);

            return View(new AllSalesModel
            {
                Sales = sales
            });
        }

        [Route("sales/discounted")]
        public IActionResult SalesWithDiscount()
        {
            var sales = this.sales.SaleWithDiscount();

            return View(new AllSalesModel
            {
                Sales = sales
            });
        }

        [Route("sales/discounted/{number}")]
        public IActionResult SalesWithGivenDiscount(decimal number)
        {
            var sales = this.sales.SaleWithGivenDiscount(number);

            return View(new AllSalesModel
            {
                Sales = sales
            });
        }

        [Route("sales/add")]
        public IActionResult Add()
        {
            var customers = this.customers.All();
            var cars = this.cars.All();

            //TODO: FIX???
            return this.View(new AddSaleModel
            {
                Customers = customers,
                Cars = cars
            });
        }

        [HttpPost]
        [Route("sales/add")]
        public IActionResult Add(string customer, string car, decimal discount)
        {
            //TODO: FIX
            return null;
        }

        [Route("sales/add/finalize")]
        public IActionResult Finalize(string customer, string car, decimal discount)
        {
            //this.sales.SaleById()
            //TODO: FIX
            return this.View();
        }
    }
}