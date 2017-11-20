namespace LearningSystem.Services.Contracts
{
    using System.Collections.Generic;
    using LearningSystem.Services.Models.User;

    public interface IAdminService
    {
        IEnumerable<UserBasicInfoModel> ListAllUsers();

        void ChangeUserRole(string id);
    }
}