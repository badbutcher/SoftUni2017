namespace Exam.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Exam.App.Infrastructure;
    using Exam.App.Services;
    using Exam.App.Services.Contracts;
    using SimpleMvc.Framework.Contracts;

    public class HomeController : BaseController
    {
        private readonly IPostService posts;
        private readonly ILogService logs;

        public HomeController()
        {
            this.posts = new PostService();
            this.logs = new LogService();
        }

        public IActionResult Index()
        {
            if (!this.IsAdmin)
            {
                IEnumerable<string> posts = this.Posts();

                this.ViewModel["posts"] = string.Join(string.Empty, posts);
            }
            else
            {
                IEnumerable<string> posts = this.Posts();

                this.ViewModel["posts"] = string.Join(string.Empty, posts);

                var rows = this.logs
                .All()
                .Select(l => $@" <div class=""card border-{l.Type.ToViewClassName()} mb-1"">
                   <div class=""card-body"">
                       <p class=""card-text"">{l}</p>
                   </div>
                </div>");

                this.ViewModel["logs"] = string.Join(string.Empty, rows);
            }

            return this.View();
        }

        private IEnumerable<string> Posts()
        {
            string search = null;
            if (this.Request.UrlParameters.ContainsKey("search"))
            {
                search = this.Request.UrlParameters["search"];
            }

            var postsData = this.posts.AllPostsForUser(search);

            return postsData
                           .Select(g => $@"<div class=""card border-primary mb-3"">
                    <div class=""card-body text-primary"">
                        <h4 class=""card-title"">{g.Title}</h4>
                        <p class=""card-text"">
                            {g.Content}
                        </p>
                    </div>
                    <div class=""card-footer bg-transparent text-right"">
                        <span class=""text-muted"">
                            Created on {g.CreatedOn} by
                            <em>
                                <strong>{g.CreatedBy}</strong>
                            </em>
                        </span>
                    </div>
                </div>");
        }
    }
}