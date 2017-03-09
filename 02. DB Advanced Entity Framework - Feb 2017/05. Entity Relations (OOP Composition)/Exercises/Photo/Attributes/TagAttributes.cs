using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Attributes
{
    using System.ComponentModel.DataAnnotations;
    public class TagAttributes : ValidationAttribute
    {
        public override bool IsValid(object tag)
        {
            string tagValue = (string)tag;

            if (!tagValue.StartsWith("#"))
            {
                return false;
            }
            if (tagValue.Contains(" ") || tagValue.Contains("\t"))
            {
                return false;
            }
            if (tagValue.Length > 20)
            {
                return false;
            }

            return true;
        }
    }
}
