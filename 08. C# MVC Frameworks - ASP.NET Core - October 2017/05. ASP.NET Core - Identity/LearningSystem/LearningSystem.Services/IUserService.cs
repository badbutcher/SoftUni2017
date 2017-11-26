namespace LearningSystem.Services
{
    using System.Threading.Tasks;
    using LearningSystem.Services.Models;

    public interface IUserService
    {
        Task<UserProfileServiceModel> ProfileAsync(string username);
    }
}