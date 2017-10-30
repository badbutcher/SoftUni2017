namespace Exam.App.Services
{
    using System.Linq;
    using Exam.App.Data;
    using Exam.App.Data.Models;
    using Exam.App.Services.Contracts;

    public class UserService : IUserService
    {
        public bool Create(string email, string password, string name)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                bool isAdmin = !db.Users.Any();

                var user = new User
                {
                    Email = email,
                    Password = password,
                    IsAdmin = isAdmin,
                    FullName = name
                };

                db.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool UserExists(string email, string password)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                return db
                    .Users
                    .Any(u => u.Email == email && u.Password == password);
            }
        }

        public string GetUserName(string email)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                return db
                    .Users
                    .FirstOrDefault(u => u.Email == email).FullName;
            }
        }
    }
}