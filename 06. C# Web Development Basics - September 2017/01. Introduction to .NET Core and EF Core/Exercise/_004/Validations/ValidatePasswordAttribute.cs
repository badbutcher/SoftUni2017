using System;
using System.ComponentModel.DataAnnotations;

namespace _004.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ValidatePasswordAttribute : ValidationAttribute
    {
        //public static ValidationResult CheckPassword(string password)
        //{
        //    char[] SpecialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '<', '>', '?' };

        //    if (password.Any(c => char.IsUpper(c)) &&
        //        password.Any(c => char.IsLower(c)) &&
        //        password.Any(c => char.IsDigit(c)) &&
        //        password.Any(c => SpecialSymbols.Contains(c)))
        //    {
        //        return ValidationResult.Success;
        //    }
        //    else
        //    {
        //        return new ValidationResult("Wrong password");
        //    }
        //}

        public override bool IsValid(object value)
        {
            string password = (string)value;

            char[] SpecialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '<', '>', '?' };

            if (password.Length > 5)
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