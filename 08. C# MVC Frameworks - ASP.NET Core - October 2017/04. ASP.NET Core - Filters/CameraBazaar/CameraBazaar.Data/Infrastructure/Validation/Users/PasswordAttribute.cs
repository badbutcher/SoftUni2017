namespace CameraBazaar.Data.Infrastructure.Validation.Users
{
    using System.Linq;

    public class PasswordAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value as string;

            if (!password.All(char.IsLower) || !password.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}