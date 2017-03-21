namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;
    using System.Linq;

    public class DeleteUserCommand
    {
        private UserService userSurvice;

        public DeleteUserCommand(UserService userSurvice)
        {
            this.userSurvice = userSurvice;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            if (!this.userSurvice.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            this.userSurvice.Delete(username);
            

            return $"User {username} was deleted successfully!";
        }
    }
}
