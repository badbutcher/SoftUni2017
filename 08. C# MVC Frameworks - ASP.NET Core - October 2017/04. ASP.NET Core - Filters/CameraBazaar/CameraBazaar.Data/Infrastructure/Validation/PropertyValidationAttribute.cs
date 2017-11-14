namespace CameraBazaar.Data.Infrastructure.Validation
{
    using System;

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class PropertyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}