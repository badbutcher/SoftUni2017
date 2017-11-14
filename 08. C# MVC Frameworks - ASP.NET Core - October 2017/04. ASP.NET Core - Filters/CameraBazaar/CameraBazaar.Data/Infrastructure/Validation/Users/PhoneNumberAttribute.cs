namespace CameraBazaar.Data.Infrastructure.Validation.Users
{
    using System.Linq;

    public class PhoneNumberAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string phone = value as string;

            if (phone.StartsWith("+") && phone.Skip(1).All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }
}