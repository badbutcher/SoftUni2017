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
        public IHttpResponse Handle(IHttpRequest request)
        {
            Dictionary<string, string> getParams = new Dictionary<string, string>(request.UrlParameters);
            Dictionary<string, string> postParams = new Dictionary<string, string>(request.FormData);
            string requestMethod = request.Method.ToString().ToUpper();

            string[] controllerParams = request.Path.Split(new[] { '?', '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (controllerParams.Length < 2)
            {
                return new NotFoundResponse();
            }

            string controllerName = $"{controllerParams[0].Captialize()}{MvcContext.Get.ControllersSuffix}";
            string actionName = controllerParams[1].Captialize();

            Controller controller = this.GetController(controllerName);

            MethodInfo method = this.GetMethod(controller, requestMethod, actionName);

            if (method == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            object[] methodParams = this.AddParameters(parameters, getParams, postParams);

            try
            {
                IHttpResponse response = this.GetResponse(method, controller, methodParams);
                return response;
            }
            catch (Exception e)
            {
                return new InternalServerErrorResponse(e);
            }

            //this.PrepareMethodParameters(methodInfo);

            //var actionResult = (IInvocable)methodInfo.Invoke(this.GetController(), this.methodParameters);

            //var content = actionResult.Invoke();

            //return new ContentResponse(HttpStatusCode.Ok, content);
        }

        private IHttpResponse GetResponse(MethodInfo method, Controller controller, object[] methodParams)
        {
            object actionResult = method.Invoke(controller, methodParams);

            IHttpResponse response = null;

            if (actionResult is IViewable)
            {
                string content = ((IViewable)actionResult).Invoke();

                response = new ContentResponse(HttpStatusCode.Ok, content);
            }
            else if (actionResult is IRedirectable)
            {
                string redirectUrl = ((IRedirectable)actionResult).Invoke();

                response = new RedirectResponse(redirectUrl);
            }

            return response;
        }

        private object[] AddParameters(IEnumerable<ParameterInfo> parameters, Dictionary<string, string> getParams, Dictionary<string, string> postParams)
        {
            object[] methodParams = new object[parameters.Count()];

            int index = 0;

            foreach (var parameter in parameters)
            {
                if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(string))
                {
                    methodParams[index] = this.ProcessPrimitiveParameter(parameter, getParams);
                    index++;
                }
                else
                {
                    methodParams[index] = this.ProcessComplexParameter(parameter, postParams);
                    index++;
                }
            }

            return methodParams;
        }

        private object ProcessComplexParameter(ParameterInfo parameter, Dictionary<string, string> postParams)
        {
            Type bindingModelType = parameter.ParameterType;

            object bindingModel = Activator.CreateInstance(bindingModelType);

            IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name], property.PropertyType));
            }

            return Convert.ChangeType(bindingModel, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo parameter, Dictionary<string, string> getParams)
        {
            object value = getParams[parameter.Name];
            return Convert.ChangeType(value, parameter.ParameterType);
        }

        //private void PrepareMethodParameters(MethodInfo methodInfo)
        //{
        //    var parameters = methodInfo.GetParameters();

        //    this.methodParameters = new object[parameters.Length];

        //    for (int i = 0; i < parameters.Length; i++)
        //    {
        //        var parameter = parameters[i];

        //        if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(string))
        //        {
        //            var getParameterValue = this.getParameters[parameter.Name];

        //            var value = Convert.ChangeType(getParameterValue, parameter.ParameterType);

        //            this.methodParameters[i] = value;
        //        }
        //        else
        //        {
        //            var modelType = parameter.ParameterType;

        //            var modelInstance = Activator.CreateInstance(modelType);

        //            var modelProperties = modelType.GetProperties();

        //            foreach (var modelProperty in modelProperties)
        //            {
        //                var postParameterValue = this.postParameters[modelProperty.Name];

        //                var value = Convert.ChangeType(postParameterValue, modelProperty.PropertyType);

        //                modelProperty.SetValue(modelInstance, value);

        //                this.methodParameters[i] = Convert.ChangeType(modelInstance, modelType);
        //            }
        //        }
        //    }
        //}

        private MethodInfo GetMethod(Controller controller, string requestMethod, string actionName)
        {
            foreach (var method in this.GetSuitableMethods(controller, actionName))
            {
                var httpMethodAttributes = method
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!httpMethodAttributes.Any() && requestMethod == "GET")
                {
                    return method;
                }

                foreach (var httpMethodAttribute in httpMethodAttributes)
                {
                    if (httpMethodAttribute.IsValid(requestMethod))
                    {
                        return method;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name == actionName);
        }

        private Controller GetController(string controllerName)
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName);

            Type type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }
    }
}