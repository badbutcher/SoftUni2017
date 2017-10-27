namespace Exam.App.Services.Contracts
{
    using System.Collections.Generic;
    using Exam.App.Data.Model;

    public interface IUserService
    {
        bool Create(string email, string password, Position position);

        bool UserExists(string email, string password);

        bool IsAproved(string email);

        IEnumerable<object> AllUsers();//~!!!!!!!!!!
    }
}