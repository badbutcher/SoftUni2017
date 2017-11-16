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

        public void Edit(string id, string email, string password, string phone, string currentPassword)
        {
            var user = this.db.Users.FirstOrDefault(a => a.Id == id);

            if (user == null)
            {
                return;
            }

            if (currentPassword != user.PasswordHash)
            {
                return;
            }

            user.Email = email;
            user.PhoneNumber = phone;
            user.PasswordHash = password; //MUST BE HASH TODO
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
                    Cameras = a.Cameras
                }).FirstOrDefault(a => a.Id == id);

            return user;
        }
    }
}