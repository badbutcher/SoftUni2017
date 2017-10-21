namespace SimpleMvc.Framework.Helpers
{
    using SimpleMvc.Framework.Controllers;

    public static class ControllerHelpers
    {
        public static string GetControllerName(Controller controller)
        {
            return controller.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);
        }

        public static string GetViewFullQualifedName(string controller, string action)
        {
            return string.Format(
                 "{0}.{1}.{2}.{3}, {0}",
                 MvcContext.Get.AssemblyName,
                 MvcContext.Get.ViewsFolder,
                 controller,
                 action);
        }
    }
}