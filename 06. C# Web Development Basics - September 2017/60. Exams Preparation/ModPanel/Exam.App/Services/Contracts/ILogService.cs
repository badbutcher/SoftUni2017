namespace Exam.App.Services.Contracts
{
    using System.Collections.Generic;
    using Exam.App.Data.Model;
    using Exam.App.Models.Logs;

    public interface ILogService
    {
        void Create(string admin, LogType type, string additionalInformation);

        IEnumerable<LogModel> All();
    }
}