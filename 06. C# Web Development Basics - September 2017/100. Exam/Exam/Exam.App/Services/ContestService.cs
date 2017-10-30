namespace Exam.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Exam.App.Data;
    using Exam.App.Data.Models;
    using Exam.App.Infrastructure;
    using Exam.App.Models.Contests;
    using Exam.App.Services.Contracts;

    public class ContestService : IContestService
    {
        public IEnumerable<ContestsViewModel> All()
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var result = db.Contests
                    .Select(a => new ContestsViewModel
                    {
                        Name = a.Name,
                        Submissions = a.Submission.Contests.Count,
                        Email = a.User.Email
                    });

                return result.ToList();
            }
        }

        public void Add(string name, int id)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                Contest contest = new Contest()
                {
                    Name = name.Capitalize(),
                    UserId = id
                };

                db.Add(contest);
                db.SaveChanges();
            }
        }

        public void Edit(string oldName, string newName)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var contest = db.Contests.FirstOrDefault(a => a.Name == oldName);

                if (contest == null)
                {
                    return;
                }

                contest.Name = newName.Capitalize();

                db.SaveChanges();
            }
        }

        public void Delete(string name)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var contest = db.Contests.FirstOrDefault(a => a.Name == name);

                if (contest == null)
                {
                    return;
                }

                db.Contests.Remove(contest);
                db.SaveChanges();
            }
        }
    }
}