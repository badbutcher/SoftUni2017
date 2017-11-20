namespace LearningSystem.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Contracts;
    using LearningSystem.Services.Models.User;
    using Microsoft.AspNetCore.Identity;

    public class AdminService : IAdminService
    {
        private readonly LearningSystemDbContext db;
        private readonly UserManager<User> userManager;

        public AdminService(LearningSystemDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public void ChangeUserRole(string id)
        {
            var user = this.userManager.FindByIdAsync(id);

            //this.userManager.AddToRoleAsync()
        }

        public IEnumerable<UserBasicInfoModel> ListAllUsers()
        {
            var users = this.db.Users
                .Select(a => new UserBasicInfoModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Username = a.UserName,
                    Email = a.Email,
                    Role = new List<string>()
                }).ToList();

            var roles = this.db.UserRoles.Select(a => a.RoleId).ToList();

            foreach (var user in users)
            {
                foreach (var role in roles)
                {
                    user.Role.AddRange(this.db.Roles.Where(a => a.Id == role).Select(c => c.Name).ToList());
                }
            }

            return users;
        }
    }
}