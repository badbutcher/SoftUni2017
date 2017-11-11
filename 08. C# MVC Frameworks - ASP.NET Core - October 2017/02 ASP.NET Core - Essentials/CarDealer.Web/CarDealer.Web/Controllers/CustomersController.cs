namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Services.Models.Enums;
    using CarDealer.Web.Infrastructure.Extensions;
    using CarDealer.Web.Models.Customers;
    using Microsoft.AspNetCore.Mvc;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route(nameof(Create))]
        public IActionResult Create() => this.View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CustomerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.customers.Create(model.Name, model.BirthDay, model.IsYoungDriver);

            return this.RedirectToAction(nameof(this.All), new { order = OrderDirection.Ascending });
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customers.ById(id);

            if (customer == null)
            {
                return this.NotFound();
            }

            return this.View(new CustomerFormModel
            {
                Name = customer.Name,
                BirthDay = customer.BirthDay,
                IsYoungDriver = customer.IsYoungDriver
            });
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, CustomerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var customerExists = this.customers.Exists(id);

            if (!customerExists)
            {
                return this.NotFound();
            }

            this.customers.Edit(id, model.Name, model.BirthDay, model.IsYoungDriver);

            return this.RedirectToAction(nameof(this.All), new { order = OrderDirection.Ascending });
        }

        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirection = order.ToLower() == "descending"
                ? OrderDirection.Descending
                : OrderDirection.Ascending;

            var customers = this.customers.Ordered(orderDirection);

            return this.View(new AllCustomersModel
            {
                Customers = customers,
                OrderDirection = orderDirection
            });
        }

        [Route("{id}")]
        public IActionResult TotalSales(int id)
        {
            return this.ViewOrNotFound(this.customers.TotalSalesById(id));
        }
    }
}