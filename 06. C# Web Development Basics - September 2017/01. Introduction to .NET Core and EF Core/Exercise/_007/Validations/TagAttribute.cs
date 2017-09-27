namespace _007.Validations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var tag = value as string;
            if (tag == null)
            {
                return true;
            }

            return tag.StartsWith("#") && tag.All(a => !char.IsWhiteSpace(a)) && tag.Length <= 20;
        }
    }
}