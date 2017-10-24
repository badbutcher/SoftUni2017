namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Data;
    using SimpleMvc.Domain.Models;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel registerUserBinding)
        {
            if (!this.IsValidModel(registerUserBinding))
            {
                return this.View();
            }

            User user = new User()
            {
                Username = registerUserBinding.Username,
                Password = registerUserBinding.Password
            };

            using (SimpleMvcDbContext context = new SimpleMvcDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.RedirectToAction("/users/login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel loginUserBinding)
        {
            using (var context = new SimpleMvcDbContext())
            {
                var foundUser = context.Users.FirstOrDefault(a => a.Username == loginUserBinding.Username);

                if (foundUser == null)
                {
                    return this.RedirectToAction("/home/login");
                }

                context.SaveChanges();
                this.SignIn(foundUser.Username);
            }

            return this.RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction("/users/login");
            }

            Dictionary<int, string> users = new Dictionary<int, string>();

            using (var context = new SimpleMvcDbContext())
            {
                users = context.Users.ToDictionary(u => u.Id, u => u.Username);
            }

            this.Model["users"] =
            users.Any() ? string.Join(string.Empty, users
            .Select(u => $"<li><a href=\"/users/profile?id={u.Key}\">{u.Value}</a></li>"))
            : string.Empty;

            return this.View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            using (SimpleMvcDbContext context = new SimpleMvcDbContext())
            {
                var user = context.Users
                    .Include(u => u.Notes)
                    .FirstOrDefault(u => u.Id == id);

                this.Model["username"] = user.Username;
                this.Model["userid"] = user.Id.ToString();
                this.Model["notes"] = string.Join(string.Empty, user.Notes
            .Select(u => $"<div>{u.Title}--{u.Content}</div>"));

                return this.View();
            }
        }

        [HttpPost]
        public IActionResult Profile(AddNoteBindingModel model)
        {
            using (SimpleMvcDbContext context = new SimpleMvcDbContext())
            {
                var user = context.Users
                    .Find(model.UserId);

                Note note = new Note
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.SaveChanges();
            }

            return this.Profile(model.UserId);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.RedirectToAction("/home/index");
        }
    }
}