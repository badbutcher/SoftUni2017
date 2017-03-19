namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    public class ModifyUserCommand
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            //string username = data[0];
            //string property = data[1];
            //string newValue = data[2];

            //using (PhotoShareContext context = new PhotoShareContext())
            //{
            //    var checkUsername = context.Users.FirstOrDefault(u => u.Username == username);

            //    if (checkUsername.Username != username)
            //    {
            //        throw new ArgumentException($"User {username} not found!");
            //    }

            //    if (property != "Password" || property != "BornTown" || property != "CurrentTown")
            //    {
            //        throw new ArgumentException($"Property {property} not supported!");
            //    }

            //}

            return "asd";
        }
    }
}
