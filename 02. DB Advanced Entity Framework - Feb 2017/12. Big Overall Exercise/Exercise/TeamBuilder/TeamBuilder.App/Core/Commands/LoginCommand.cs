namespace TeamBuilder.App.Core.Commands
{
    using System.Linq;
    using Utilities;
    using Data;
    using Models;
    using System;

    public class LoginCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLenght(2, inputArgs);

            string username = inputArgs[0];
            string password = inputArgs[1];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            User user = this.GetUserByCredentials(username, password);

            if (user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            AuthenticationManager.Login(user);

            return $"User {user.Username} successfully logged in!";
        }

        private User GetUserByCredentials(string username, string password)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username && u.IsDeleted == false && u.Password == password);

                return user;
            }
        }
    }
}