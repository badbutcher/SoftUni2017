namespace CameraBazaar.Services.Contracts
{
    using CameraBazaar.Services.Models.Users;

    public interface IUserService
    {
        UserBasicInfoModel GetUserInfo(string id);

        void Edit(string id, string email, string password, string phone, string currentPassword);
    }
}