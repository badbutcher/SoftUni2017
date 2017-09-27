namespace _005.Validations
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ValidatePasswordAttribute : ValidationAttribute
    {
        public ValidatePasswordAttribute()
        {
            this.ErrorMessage = "Wrong password";
        }

        public override bool IsValid(object value)
        {
            string password = (string)value;

            char[] specialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '<', '>', '?' };

            if (password.Any(c => char.IsUpper(c)) &&
                password.Any(c => char.IsLower(c)) &&
                password.Any(c => char.IsDigit(c)) &&
                password.Any(c => specialSymbols.Contains(c)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}