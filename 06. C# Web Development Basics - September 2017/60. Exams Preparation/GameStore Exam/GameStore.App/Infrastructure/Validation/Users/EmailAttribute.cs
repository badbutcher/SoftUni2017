namespace GameStore.App.Infrastructure.Validation.Users
{
    using SimpleMvc.Framework.Attributes.Property;

    public class EmailAttribute : PropertyAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;

            if (email.Contains("@") && email.Contains("."))
            {
                return true;
            }

            return false;
        }
    }
}