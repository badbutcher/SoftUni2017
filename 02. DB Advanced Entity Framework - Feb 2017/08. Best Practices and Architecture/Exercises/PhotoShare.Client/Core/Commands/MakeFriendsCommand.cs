namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;

    public class MakeFriendsCommand
    {
        private UserService userService;

        public MakeFriendsCommand(UserService userSurvice)
        {
            this.userService = userSurvice;
        }

        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            string usernameOne = data[0];
            string usernameTwo = data[1];

            if (!this.userService.IsUserExisting(usernameOne))
            {
                throw new ArgumentException($"{usernameOne} not found!");
            }

            if (!this.userService.IsUserExisting(usernameTwo))
            {
                throw new ArgumentException($"{usernameTwo} not found!");
            }

            if (userService.CheckIfAreFriends(usernameOne, usernameTwo))
            {
                throw new ArgumentException($"{usernameTwo} is already a friend to {usernameOne}");
            }

            userService.AddFriends(usernameOne, usernameTwo);

            return $"Friend {usernameTwo} added to {usernameOne}";
        }
    }
}
