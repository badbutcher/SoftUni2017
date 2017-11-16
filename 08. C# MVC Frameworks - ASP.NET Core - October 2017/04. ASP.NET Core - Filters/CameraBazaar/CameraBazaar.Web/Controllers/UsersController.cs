namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Services.Contracts;
    using CameraBazaar.Services.Models.Users;
    using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Edit(string id)
        {
            var user = this.users.GetUserInfo(id);

            return this.View(new UserEditModel
            {
                Email = user.Email, //TODO
            });
        }
    }
}