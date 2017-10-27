namespace Exam.App.Services.Contracts
{
    using Exam.App.Data.Model;

    public interface IUserService
    {
        bool Create(string email, string password, Position position);

        bool UserExists(string email, string password);

        bool IsAproved(string email);
    }
}