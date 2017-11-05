namespace Cars.Controllers
{
    using Car.Services;
    using Cars.Models.Sales;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : Controller
    {
        private readonly ISaleService sale;

        public SalesController(ISaleService sale)
        {
            this.sale = sale;
        }

        [Route("sales")]
        public IActionResult AllSales()
        {
            var sales = this.sale.AllSales();

            return View(new AllSalesModel
            {
                Sales = sales
            });
        }

        [Route("sales/{id}")]
        public IActionResult SalesById(int id)
        {
            var sales = this.sale.SaleById(id);

            return View(new AllSalesModel
            {
                Sales = sales
            });
        }

        [Route("sales/discounted")]
        public IActionResult SalesWithDiscount()
        {
            var sales = this.sale.SaleWithDiscount();

            return View(new AllSalesModel
            {
                Sales = sales
            });
        }

        [Route("sales/discounted/{number}")]
        public IActionResult SalesWithGivenDiscount(decimal number)
        {
            var sales = this.sale.SaleWithGivenDiscount(number);

            return View(new AllSalesModel
            {
                Sales = sales
            });
        }
    }
}