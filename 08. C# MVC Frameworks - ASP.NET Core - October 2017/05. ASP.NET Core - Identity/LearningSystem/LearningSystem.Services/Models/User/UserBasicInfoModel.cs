namespace LearningSystem.Services.Models.User
{
    using System.Collections.Generic;

    public class UserBasicInfoModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<string> Role { get; set; }
    }
}