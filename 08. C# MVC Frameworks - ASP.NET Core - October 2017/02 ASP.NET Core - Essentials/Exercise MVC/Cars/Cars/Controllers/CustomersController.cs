namespace Cars.Controllers
{
    using Car.Services;
    using Car.Services.Models;
    using Cars.Models.Customers;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route("customers/all/{order?}")]
        public IActionResult All(string order)
        {
            if (order == null)
            {
                order = "ascending";
            }

            var orderDirection = order.ToLower() == "descending"
                ? OrderDirection.Descending
                : OrderDirection.Ascending;

            var customers = this.customers.OrderCustomers(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = customers,
                GetOrderDirection = orderDirection
            });
        }

        [Route("/customers/{id}")]
        public IActionResult CustomerCars(int id)
        {
            var customer = this.customers.CustomerCars(id);

            return View(new CustomerCarsModel
            {
                Customer = customer
            });
        }
    }
}