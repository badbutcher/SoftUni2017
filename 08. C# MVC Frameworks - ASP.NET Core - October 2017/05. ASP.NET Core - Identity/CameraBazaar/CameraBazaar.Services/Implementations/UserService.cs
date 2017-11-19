namespace CameraBazaar.Services.Implementations
{
    using System.Linq;
    using CameraBazaar.Data;
    using CameraBazaar.Services.Contracts;
    using CameraBazaar.Services.Models.Users;

    public class UserService : IUserService
    {
        private readonly CameraBazaarDbContext db;

        public UserService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public UserBasicInfoModel GetUserInfo(string id)
        {
            var user = this.db.Users
                .Select(a => new UserBasicInfoModel
                {
                    Id = a.Id,
                    Username = a.UserName,
                    Email = a.Email,
                    PhoneNumber = a.PhoneNumber,
                    LastLoginTime = a.LastLoginTime,
                    Cameras = a.Cameras
                }).FirstOrDefault(a => a.Id == id);

            return user;
        }
    }
}