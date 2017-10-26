namespace GameStore.App.Infrastructure.Validation.Users
{
    using System.Linq;
    using SimpleMvc.Framework.Attributes.Property;

    public class PasswordAttribute : PropertyAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value as string;

            if (password.Length >= 6 &&
                password.Any(a => char.IsUpper(a)) &&
                password.Any(a => char.IsLower(a)) &&
                password.Any(a => char.IsDigit(a)))
            {
                return true;
            }

            return false;
        }
    }
}