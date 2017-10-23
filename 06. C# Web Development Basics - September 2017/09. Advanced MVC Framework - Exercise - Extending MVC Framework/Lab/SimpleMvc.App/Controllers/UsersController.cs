namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.App.ViewModels;
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

            return this.View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All()
        {
            Dictionary<int, string> users = null;
            using (SimpleMvcDbContext context = new SimpleMvcDbContext())
            {
                users = context.Users.Select(a => new KeyValuePair<int, string>(a.Id, a.Username)).ToDictionary(b => b.Key, b => b.Value);
            }

            var viewModel = new AllUsernamesViewModel()
            {
                Users = users
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (SimpleMvcDbContext context = new SimpleMvcDbContext())
            {
                var user = context.Users
                    .Include(u => u.Notes)
                    .FirstOrDefault(u => u.Id == id);

                var viewModel = new UserProfileViewModel()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = user.Notes
                    .Select(a => new NoteViewModel()
                    {
                        Title = a.Title,
                        Content = a.Content
                    })
                };

                return this.View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
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
    }
}