namespace LearningSystem.Services.Implementations
{
    using LearningSystem.Data;
    using LearningSystem.Services.Contracts;

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;

        public UserService(LearningSystemDbContext db)
        {
            this.db = db;
        }
    }
}