namespace TeamBuilder.App.Core.Commands
{
    using System.Linq;
    using Utilities;
    using Data;
    using Models;

    public class DeleteUserCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLenght(0, inputArgs);
            AuthenticationManager.Athorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            DeleteUser(currentUser);

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} was deleted successfully!";
        }

        private static void DeleteUser(User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                context.Users.SingleOrDefault(u => u.Id == user.Id).IsDeleted = true;
                context.SaveChanges();
            }
        }
    }
}