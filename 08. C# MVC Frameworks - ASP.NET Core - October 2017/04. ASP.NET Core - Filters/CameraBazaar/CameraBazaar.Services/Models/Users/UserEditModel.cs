namespace CameraBazaar.Services.Models.Users
{
    using System;

    public class UserEditModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string CurrentPassword { get; set; }

        public DateTime LastLoginTime { get; set; }
    }
}