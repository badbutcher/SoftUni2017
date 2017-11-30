namespace BookShop.Web.Areas.Api.Controllers
{
    using BookShop.Services.Contracts;
    using BookShop.Services.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategorieService categories;

        public CategoriesController(ICategorieService categories)
        {
            this.categories = categories;
        }

        [HttpPost]
        [Route("AddCategorie")]
        public IActionResult AddCategorie([FromBody]CategorieServiceModel model)
        {
            var exists = this.categories.Add(model);

            if (!exists)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route("DeleteCategorie/{id}")]
        public IActionResult DeleteCategorie(int id)
        {
            this.categories.Delete(id);

            return this.Ok();
        }

        [HttpPut]
        [Route("EditCategorie/{id}")]
        public IActionResult EditCategorie(int id, [FromBody]CategorieServiceModel model)
        {
            this.categories.Edit(id, model);

            return this.Ok();
        }

        [HttpGet]
        [Route("AllCategorie")]
        public IActionResult AllCategorie()
        {
            var all = this.categories.All();

            return this.Ok(all);
        }

        [HttpGet]
        [Route("CategorieById/{id}")]
        public IActionResult CategorieById(int id)
        {
            var result = this.categories.ById(id);

            return this.Ok(result);
        }
    }
}