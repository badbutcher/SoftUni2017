namespace Exam.App.Infrastructure.Posts
{
    using SimpleMvc.Framework.Attributes.Validation;

    public class CapitalizeAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string str = value as string;

            if (str == null)
            {
                return false;
            }

            if (str.Length >= 3 && str.Length <= 100 && char.IsUpper(str[0]))
            {
                return true;
            }

            return false;
        }
    }
}