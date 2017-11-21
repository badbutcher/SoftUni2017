namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Services.Contracts;
    using CameraBazaar.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize(Roles = "Logged In, Admin")]
    [Authorize(Roles = GlocalConstants.AdminRole + ", " + GlocalConstants.LoggedInUserRole)]
    //[Authorize(Roles = GlocalConstants.LoggedInUserRole)]
    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        public IActionResult Profile(string id)
        {
            var user = this.users.GetUserInfo(id);

            return this.View(user);
        }
    }
}