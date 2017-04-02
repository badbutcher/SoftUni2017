namespace TeamBuilder.App.Core.Commands
{
    using Utilities;
    using Models;

    public class LogoutCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLenght(0, inputArgs);
            AuthenticationManager.Athorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} successfully logged out!";
        }
    }
}