namespace Exam.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class SubmissionsController : BaseController
    {
        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }
    }
}
