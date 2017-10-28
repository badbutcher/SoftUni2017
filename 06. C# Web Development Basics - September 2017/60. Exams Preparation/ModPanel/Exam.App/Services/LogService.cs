namespace Exam.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Exam.App.Data;
    using Exam.App.Data.Model;
    using Exam.App.Models.Logs;
    using Exam.App.Services.Contracts;

    public class LogService : ILogService
    {
        public void Create(string admin, LogType type, string additionalInformation)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                Log log = new Log
                {
                    Admin = admin,
                    Type = type,
                    AdditionalInformation = additionalInformation
                };

                db.Logs.Add(log);
                db.SaveChanges();
            }
        }

        public IEnumerable<LogModel> All()
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                return db
                    .Logs
                    .OrderByDescending(l => l.Id)
                    .Select(l => new LogModel
                    {
                        Admin = l.Admin,
                        Type = l.Type,
                        AdditionalInformation = l.AdditionalInformation
                    })
                    .ToList();
            }
        }
    }
}