namespace Exam.App.Services.Contracts
{
    using System.Collections.Generic;
    using Exam.App.Models.Admin;

    public interface IAdminService
    {
        IEnumerable<UsersInfoViewModel> AllUsers();

        string Approve(int id);
    }
}