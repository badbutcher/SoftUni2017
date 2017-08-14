namespace CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle
{
    using System;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Request;

    public class RequestMappingAttribute : Attribute
    {
        private readonly string value;

        private readonly RequestMethod method;

        public RequestMappingAttribute(string value, RequestMethod method = RequestMethod.ADD)
        {
            this.value = value;
            this.method = method;
        }

        public string Value
        {
            get { return this.value; }
        }

        public RequestMethod Method
        {
            get { return this.method; }
        }
    }
}
