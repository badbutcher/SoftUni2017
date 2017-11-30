namespace BookShop.Web.Areas.Api.Controllers
{
    using BookShop.Services.Contracts;
    using BookShop.Services.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/Books")]
    public class BooksController : Controller
    {
        private readonly IBookService books;

        public BooksController(IBookService books)
        {
            this.books = books;
        }

        [HttpGet]
        [Route("GetDataAboutBookFromId/{id}")]
        public IActionResult GetDataAboutBookFromId(int id)
        {
            var book = this.books.BookDataById(id);

            return this.Ok(book);
        }

        [HttpGet]
        [Route("GetTopTenBooksBySubstring/{text}")]
        public IActionResult GetTopTenBooksBySubstring(string text)
        {
            var book = this.books.TopBooksBySubstring(text);

            return this.Ok(book);
        }

        [HttpPut]
        [Route("EditBook/{id}")]
        public IActionResult EditBook(int id, [FromBody]EditBookServiceModel model)
        {
            this.books.EditBookById(id, model);

            return this.Ok();
        }

        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            this.books.DeleteBookById(id);

            return this.Ok();
        }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook([FromBody]FullBookInfoServiceModel model)
        {
            this.books.AddNewBook(model);

            return this.Ok();
        }
    }
}