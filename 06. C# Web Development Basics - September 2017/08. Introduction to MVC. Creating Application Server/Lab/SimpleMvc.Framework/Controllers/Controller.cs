namespace SimpleMvc.Framework.Controllers
{
    using System.Runtime.CompilerServices;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Contracts.Generic;
    using SimpleMvc.Framework.Helpers;
    using SimpleMvc.Framework.ViewEngine;
    using SimpleMvc.Framework.ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string fullQualifiedName = ControllerHelpers.GetViewFullQualifedName(controllerName, caller);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifiedName = ControllerHelpers.GetViewFullQualifedName(controller, action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, [CallerMemberName]string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string viewFullQualifedName = ControllerHelpers.GetViewFullQualifedName(controllerName, caller);

            return new ActionResult<TModel>(viewFullQualifedName, model);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, string controller, string action)
        {
            string viewFullQualifedName = ControllerHelpers.GetViewFullQualifedName(controller, action);

            return new ActionResult<TModel>(viewFullQualifedName, model);
        }
    }
}