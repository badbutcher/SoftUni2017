namespace CameraBazaar.Services.Contracts
{
    using CameraBazaar.Services.Models.Users;

    public interface IUserService
    {
        UserBasicInfoModel GetUserInfo(string id);
    }
}