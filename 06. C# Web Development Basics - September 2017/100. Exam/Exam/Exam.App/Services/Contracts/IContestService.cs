namespace Exam.App.Services.Contracts
{
    using System.Collections.Generic;
    using Exam.App.Models.Contests;

    public interface IContestService
    {
        IEnumerable<ContestsViewModel> All();

        void Add(string name, int id);

        void Edit(string oldName, string newName);

        void Delete(string name);
    }
}