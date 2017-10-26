using System.Linq;
using GameStore.App.Data;
using GameStore.App.Data.Models;
using GameStore.App.Services.Contracts;

namespace GameStore.App.Services
{
    public class UserService : IUserService
    {
        public bool Create(string email, string fullname, string password)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                if (db.Users.Any(a => a.Email == email))
                {
                    return false;
                }

                bool isAdmin = !db.Users.Any();

                User user = new User
                {
                    Email = email,
                    Name = fullname,
                    Password = password,
                    IsAdmin = isAdmin
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool Exists(string email, string password)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                return db.Users
                    .Any(u => u.Email == email && u.Password == password);
            }
        }
    }
}