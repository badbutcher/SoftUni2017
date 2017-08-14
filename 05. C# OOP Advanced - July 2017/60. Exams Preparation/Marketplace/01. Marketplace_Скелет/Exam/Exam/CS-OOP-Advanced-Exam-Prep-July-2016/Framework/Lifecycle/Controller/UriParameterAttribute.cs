namespace CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Controller
{
    using System;

    public class UriParameterAttribute : Attribute
    {
        private readonly string value;

        public UriParameterAttribute(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return this.value; }
        }
    }
}
