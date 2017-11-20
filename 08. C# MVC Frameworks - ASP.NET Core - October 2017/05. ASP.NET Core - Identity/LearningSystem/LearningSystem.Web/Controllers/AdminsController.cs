namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Services.Contracts;
    using LearningSystem.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlocalConstants.Administrator)]
    public class AdminsController : Controller
    {
        private readonly IAdminService admins;

        public AdminsController(IAdminService admins)
        {
            this.admins = admins;
        }

        public IActionResult AllUsers()
        {
            var allUsers = this.admins.ListAllUsers();

            return this.View(allUsers);
        }

        public IActionResult ChangeUserRole()
        {
            return this.View();
        }
    }
}