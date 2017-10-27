namespace Exam.App.Services
{
    using System.Linq;
    using Exam.App.Data;
    using Exam.App.Data.Model;
    using Exam.App.Services.Contracts;

    public class UserService : IUserService
    {
        public bool Create(string email, string password, Position position)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                var isAdmin = !db.Users.Any();

                User user = new User
                {
                    Email = email,
                    Password = password,
                    IsAdmin = isAdmin,
                    IsApproved = isAdmin,
                    Position = position
                };

                db.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool IsAproved(string email)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                return db
                    .Users
                    .Any(u => u.Email == email && u.IsApproved);
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
    }
}