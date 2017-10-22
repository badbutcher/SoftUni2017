namespace SimpleMvc.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Helpers;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParameters;
        private IDictionary<string, string> postParameters;
        private string requestMethod;
        private Controller controllerInstance;
        private string controllerName;
        private string actionName;
        private object[] methodParameters;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParameters = new Dictionary<string, string>(request.UrlParameters);
            this.postParameters = new Dictionary<string, string>(request.FormData);
            this.requestMethod = request.Method.ToString().ToUpper();

            var pathParts = request.Path.Split(new[] { '?', '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (pathParts.Length < 2)
            {
                return new NotFoundResponse();
            }

            this.controllerName = $"{pathParts[0].Captialize()}{MvcContext.Get.ControllersSuffix}";
            this.actionName = pathParts[1].Captialize();

            var methodInfo = this.GetActionForExecution();

            if (methodInfo == null)
            {
                return new NotFoundResponse();
            }

            this.PrepareMethodParameters(methodInfo);

            var actionResult = (IInvocable)methodInfo.Invoke(this.GetControllerInstance(), this.methodParameters);

            var content = actionResult.Invoke();

            return new ContentResponse(HttpStatusCode.Ok, content);
        }

        private void PrepareMethodParameters(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();

            this.methodParameters = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];

                if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(string))
                {
                    var getParameterValue = this.getParameters[parameter.Name];

                    var value = Convert.ChangeType(getParameterValue, parameter.ParameterType);

                    this.methodParameters[i] = value;
                }
                else
                {
                    var modelType = parameter.ParameterType;

                    var modelInstance = Activator.CreateInstance(modelType);

                    var modelProperties = modelType.GetProperties();

                    foreach (var modelProperty in modelProperties)
                    {
                        var postParameterValue = this.postParameters[modelProperty.Name];

                        var value = Convert.ChangeType(postParameterValue, modelProperty.PropertyType);

                        modelProperty.SetValue(modelInstance, value);

                        this.methodParameters[i] = Convert.ChangeType(modelInstance, modelType);
                    }
                }
            }
        }

        private MethodInfo GetActionForExecution()
        {
            foreach (var method in this.GetSuitableMethods())
            {
                var httpMethodAttributes = method
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!httpMethodAttributes.Any() && this.requestMethod == "GET")
                {
                    return method;
                }

                foreach (var httpMethodAttribute in httpMethodAttributes)
                {
                    if (httpMethodAttribute.IsValid(this.requestMethod))
                    {
                        return method;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var controller = this.GetControllerInstance();

            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller.GetType().GetMethods().Where(m => m.Name == actionName);
        }

        private Controller GetControllerInstance()
        {
            //if (this.controllerInstance != null)
            //{
            //    return this.controllerInstance;
            //}

            var controllerFullQualifedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                this.controllerName);

            var controllerType = Type.GetType(controllerFullQualifedName);

            if (controllerType == null)
            {
                return null;
            }

            controllerInstance = (Controller)Activator.CreateInstance(controllerType);

            return controllerInstance;
        }
    }
}