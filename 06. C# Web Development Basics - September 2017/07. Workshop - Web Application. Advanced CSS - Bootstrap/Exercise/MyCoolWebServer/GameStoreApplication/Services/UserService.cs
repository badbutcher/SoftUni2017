using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MyCoolWebServer.GameStoreApplication.Data;
using MyCoolWebServer.GameStoreApplication.Data.Models;

namespace MyCoolWebServer.GameStoreApplication.Services
{
    public class UserService : IUserService
    {
        public bool Create(string email, string username, string password)
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
                    Name = username,
                    Password = password,
                    IsAdmin = isAdmin
                };

                db.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool Find(string email, string password)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                if (db.Users.Any(a => a.Email == email && a.Password == password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}