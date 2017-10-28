namespace Exam.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Exam.App.Data;
    using Exam.App.Data.Model;
    using Exam.App.Models.Admin;
    using Exam.App.Services.Contracts;

    public class AdminService : IAdminService
    {
        public IEnumerable<UsersInfoViewModel> AllUsers()
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var users = db.Users
                     .Select(a => new UsersInfoViewModel
                     {
                         Id = a.Id,
                         Email = a.Email,
                         Possiton = a.Position,
                         IsAproved = a.IsApproved,
                         Posts = a.Posts.Count
                     });

                return users.ToList();
            }
        }

        public string Approve(int id)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                User user = db.Users.FirstOrDefault(a => a.Id == id);

                user.IsApproved = true;

                db.SaveChanges();

                return user?.Email;
            }
        }
    }
}