namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService sales;

        public SalesController(ISaleService sales)
        {
            this.sales = sales;
        }

        [Route("")]
        public IActionResult All()
        {
            var sales = this.sales.All();

            return this.View(sales);
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var sales = this.sales.Details(id);

            return this.View(sales);
        }
    }
}