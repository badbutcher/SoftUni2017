namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Services;
    using System;
    using System.Linq;

    public class ModifyUserCommand
    {
        private UserService userService;

        private TownService townService;

        public ModifyUserCommand(UserService userSurvice, TownService townService)
        {
            this.userService = userSurvice;
            this.townService = townService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string propType = data[1];
            string value = data[2];

            if (!this.userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            User user = this.userService.GetUserByUsername(username);

            if (propType == "Password")
            {
                if (!(value.Any(c=> char.IsLower(c)) && value.Any(c => char.IsDigit(c))))
                {
                    throw new ArgumentException($"Value {value} not valid.\nInvalid Password");
                }

                user.Password = value;
            }
            else if (propType == "BornTown")
            {
                if (!this.townService.IsTownExisting(value))
                {
                    throw new ArgumentException($"Value {value} not valid.\nTown {value} not found!");
                }

                user.BornTown = this.townService.GetTownByTownName(value);
            }
            else if (propType == "CurrentTown")
            {
                if (!this.townService.IsTownExisting(value))
                {
                    throw new ArgumentException($"Value {value} not valid.\nTown {value} not found!");
                }

                user.CurrentTown = this.townService.GetTownByTownName(value);
            }
            else
            {
                throw new ArgumentException($"Property {propType} not supported!");
            }

            this.userService.UpdateUser(user);

            return $"User {username} {propType} is {value}.";
        }
    }
}
