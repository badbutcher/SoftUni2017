namespace SimpleMvc.Framework.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using SimpleMvc.Framework.Attributes.Property;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Helpers;
    using SimpleMvc.Framework.Models;
    using SimpleMvc.Framework.ViewEngine.ActionResults;
    using SimpleMvc.Framework.Views;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
        }

        protected ViewModel Model { get; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            string fullQualifedName = string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

            IRenderable view = new View(fullQualifedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected bool IsValidModel(object bindingModel)
        {
            foreach (var property in bindingModel.GetType().GetProperties())
            {
                IEnumerable<Attribute> attributes =
                    property.GetCustomAttributes()
                        .Where(a => a is PropertyAttribute);

                if (!attributes.Any())
                {
                    continue;
                }

                foreach (PropertyAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(bindingModel)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

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