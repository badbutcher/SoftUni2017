namespace News.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using News.Services;
    using News.Services.Models;

    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> All()
        {
            var result = await this.news.AllAsync();

            return this.Ok(result);
        }

        [HttpGet]
        [Route("single/{id}")]
        public async Task<IActionResult> Single(int id)
        {
            var result = await this.news.SingleNewsAsync(id);

            return this.Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]NewsInfoServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = await this.news.AddNewsAsync(model);

            return this.CreatedAtAction("Single", new { id = news.Id }, model);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]NewsInfoServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = await this.news.EditNewsAsync(id, model);

            if (news == null)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var news = await this.news.DeleteNewsAsync(id);

            if (news == null)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }
    }
}