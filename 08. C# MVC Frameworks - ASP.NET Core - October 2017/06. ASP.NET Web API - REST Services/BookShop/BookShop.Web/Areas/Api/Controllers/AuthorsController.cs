namespace BookShop.Web.Areas.Api.Controllers
{
    using BookShop.Services.Contracts;
    using BookShop.Services.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/Authors")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet]
        [Route("GetAuthorById/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = this.authors.AuthorById(id);

            return this.Ok(author);
        }

        [HttpPost]
        [Route("CreateAuthor")]
        public IActionResult CreateAuthor([FromBody]CreateAuthorServiceModel model)
        {
            this.authors.CreateAuthor(model);

            return this.Ok();
        }

        [HttpGet]
        [Route("GetBooksByAuthorId/{id}/books")]
        public IActionResult GetBooksByAuthorId(int id)
        {
            var author = this.authors.BooksByAuthorId(id);

            return this.Ok(author);
        }
    }
}