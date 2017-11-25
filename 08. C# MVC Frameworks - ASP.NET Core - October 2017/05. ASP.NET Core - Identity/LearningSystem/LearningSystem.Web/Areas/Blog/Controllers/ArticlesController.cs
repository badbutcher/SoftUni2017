namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using System.Threading.Tasks;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Blog;
    using LearningSystem.Services.Html;
    using LearningSystem.Web.Areas.Blog.Models.Articles;
    using LearningSystem.Web.Infrastructure.Extensions;
    using LearningSystem.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstats.BlogArea)]
    [Authorize(Roles = WebConstats.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService html;
        private readonly UserManager<User> userManager;
        private readonly IBlogArticleService articles;

        public ArticlesController(IHtmlService html, UserManager<User> userManager, IBlogArticleService articles)
        {
            this.html = html;
            this.userManager = userManager;
            this.articles = articles;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        {
            return this.View(new ArticleListingViewModel
            {
                Artciles = await this.articles.AllAsync(page),
                TotalArticles = await this.articles.TotalAsync(),
                CurrentPage = page
            });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var result = await this.articles.ById(id);

            return this.ViewOrNotFound(result);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [ValidateModelState]
        [HttpPost]
        public async Task<IActionResult> Create(PublishArticleFormModel model)
        {
            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.articles.CreateAsync(model.Title, model.Content, userId);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}