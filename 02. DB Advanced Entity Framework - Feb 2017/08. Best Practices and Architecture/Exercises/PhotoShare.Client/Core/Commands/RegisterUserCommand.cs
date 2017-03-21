namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Models;
    using Services;

    public class RegisterUserCommand
    {
        private UserService userService;

        public RegisterUserCommand(UserService userService)
        {
            this.userService = userService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (this.userService.IsUserExisting(username))
            {
                throw new ArgumentException($"Username {username} is already taken!");
            }

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            this.userService.RegisterUser(username, password, email);

            return "User " + username + " was registered successfully!";
        }
    }
}
