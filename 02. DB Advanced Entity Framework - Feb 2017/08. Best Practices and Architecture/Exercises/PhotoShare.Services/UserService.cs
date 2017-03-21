using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Services
{
    public class UserService
    {
        public void RegisterUser(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void Delete(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username);

                if (user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if (user.IsDeleted != null && user.IsDeleted.Value)
                {
                    throw new InvalidOperationException($"User {username} is already deleted!");
                }

                user.IsDeleted = true;
                context.SaveChanges();
            }
        }

        public bool IsUserExisting(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public User GetUserByUsername(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }

        public void UpdateUser(User updatedUser)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User userToUpdate = context.Users
                    .Include("BornTown")
                    .Include("CurrentTown")
                    .SingleOrDefault(u => u.Id == updatedUser.Id);

                if (userToUpdate != null)
                {
                    if (updatedUser.Password != userToUpdate.Password)
                    {
                        userToUpdate.Password = updatedUser.Password;
                    }

                    if (updatedUser.BornTown != null && 
                        (userToUpdate.BornTown == null || updatedUser.BornTown.Id != userToUpdate.BornTown.Id))
                    {
                        userToUpdate.BornTown = context.Towns.Find(updatedUser.BornTown.Id);
                    }

                    if (updatedUser.CurrentTown != null &&
                        (userToUpdate.CurrentTown == null || updatedUser.CurrentTown.Id != userToUpdate.CurrentTown.Id))
                    {
                        userToUpdate.CurrentTown  = context.Towns.Find(updatedUser.CurrentTown.Id);
                    }

                    context.SaveChanges();
                }
            }
        }

        public bool CheckIfAreFriends(string usernameOne, string usernameTwo)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users
                    .SingleOrDefault(u => u.Username == usernameOne)
                    .Friends.Any(u => u.Username == usernameTwo);
            }
        }

        public void AddFriends(string usernameOne, string usernameTwo)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User u1 = context.Users.SingleOrDefault(u => u.Username == usernameOne);
                User u2 = context.Users.SingleOrDefault(u => u.Username == usernameTwo);

                u1.Friends.Add(u2);
                u2.Friends.Add(u1);

                context.SaveChanges();
            }
        }

        public List<string> ListFriends(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users
                    .SingleOrDefault(u => u.Username == username)
                    .Friends.Select(u => u.Username).ToList();
            }
        }

        public bool DoesTheUserOwnAnAlbum(int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.AlbumRoles
                    .Any(a => a.Album.Id == albumId);
            }
        }
    }
}
