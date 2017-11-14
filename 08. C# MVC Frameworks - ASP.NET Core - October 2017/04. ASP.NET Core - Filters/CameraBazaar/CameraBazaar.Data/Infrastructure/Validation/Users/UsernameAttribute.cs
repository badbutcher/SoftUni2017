using System.Linq;

namespace CameraBazaar.Data.Infrastructure.Validation.Users
{
    public class UsernameAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string username = value as string;

            if (username.Length >= 4 && username.Length <= 20 && username.All(char.IsLetter))
            {
                return true;
            }

            return false;
        }
    }
}