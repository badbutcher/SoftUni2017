namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;

    public class PrintFriendsListCommand
    {
        private UserService userService;

        public PrintFriendsListCommand(UserService userSurvice)
        {
            this.userService = userSurvice;
        }

        public string Execute(string[] data)
        {
            string username = data[0];

            if (!this.userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var result = userService.ListFriends(username);

            if (result.Count == 0)
            {
                return "No friends for this user. ☹";
            }

            return $"Friends:\n-{String.Join("\n", result)}";
        }
    }
}