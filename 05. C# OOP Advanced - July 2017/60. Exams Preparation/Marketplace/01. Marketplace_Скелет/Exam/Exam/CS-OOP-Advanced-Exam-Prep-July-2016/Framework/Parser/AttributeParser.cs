namespace CS_OOP_Advanced_Exam_Prep_July_2016.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Component;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Controller;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Request;

    public class AttributeParser : IParser
    {
        /// <summary>
        /// Association of Request Method => URI => Controller.Action()
        /// e.g. "GET" => "/users/6" => {"UsersController", "Get(id)"}
        /// </summary>
        private Dictionary<RequestMethod, Dictionary<string, ControllerActionPair>> controllers;

        /**
        * A component is any bean that can be injected by any resolver
        * The association kept here is:
        *     "Abstraction" => "Implementation"
        */
        private Dictionary<Type, Type> components;

        public AttributeParser()
        {
            this.controllers = new Dictionary<RequestMethod, Dictionary<string, ControllerActionPair>>();
            this.components = new Dictionary<Type, Type>();
        }

        public Dictionary<RequestMethod, Dictionary<string, ControllerActionPair>> Controllers
        {
            get
            {
                return controllers;
            }
        }

        public Dictionary<Type, Type> Components
        {
            get
            {
                return components;
            }
        }

        public void Parse()
        {

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {                            
                if (type.GetCustomAttributes().Any(x => x.GetType() == typeof(ControllerAttribute)))
                {
                    foreach (var currentMethod in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                    {
                        if (currentMethod.GetCustomAttributes().Any(x => x.GetType() == typeof(RequestMappingAttribute)))
                        {
                            RequestMappingAttribute requestMapping = currentMethod.GetCustomAttribute<RequestMappingAttribute>();
                            RequestMethod requestMethod = requestMapping.Method;
                            string mapping = requestMapping.Value;
                            List<string> mappingTokens = mapping.Split('/').ToList();

                            Dictionary<int, Type> argumentsMapping = new Dictionary<int, Type>();

                            for (int i = 0; i < mappingTokens.Count; i++)
                            {
                                if (mappingTokens[i].StartsWith("{") && mappingTokens[i].EndsWith("}"))
                                {
                                    foreach (ParameterInfo parameterInfo in currentMethod.GetParameters())
                                    {
                                        if (parameterInfo.GetCustomAttributes().All(x => x.GetType() != typeof(UriParameterAttribute)))
                                        {
                                            continue;
                                        }

                                        UriParameterAttribute uriParameter =
                                            parameterInfo.GetCustomAttribute<UriParameterAttribute>();
                                        if (mappingTokens[i].Equals("{" + uriParameter.Value + "}"))
                                        {
                                            argumentsMapping.Add(i, parameterInfo.ParameterType);


                                            mapping = mapping.Replace(mappingTokens[i].ToString(), parameterInfo.ParameterType == typeof(string) ? "\\w+" : "\\d+");
                                            break;
                                        }
                                    }
                                }
                            }

                            Object controllerInstance = Activator.CreateInstance(type);

                            ControllerActionPair pair = new ControllerActionPair(controllerInstance, currentMethod, argumentsMapping);

                            if (!this.Controllers.ContainsKey(requestMethod))
                            {
                                this.Controllers.Add(requestMethod, new Dictionary<string, ControllerActionPair>());
                            }

                            this.Controllers[requestMethod].Add(mapping, pair);
                        }
                    }
                }
                else if (type.GetCustomAttributes().Any(x => x.GetType() == typeof(ComponentAttribute)))
                {
                    foreach (Type parent in type.GetInterfaces())
                    {
                        this.Components.Add(parent, type);
                    }
                }
            }

            foreach (ControllerActionPair controllerActionPair in this.Controllers.Values.SelectMany(x => x.Values))
            {
                this.ResolveDependencies(controllerActionPair.Controller);
            }
        }

        public T Resolve<T>()
        {
            if (!this.components.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException("Cannot map dependency of type "
                    + typeof(T).Name
                    + ". It is not annotated with @Component ");
            }

            T result = Activator.CreateInstance<T>();

            this.ResolveDependencies(result);

            return result;
        }

        private void ResolveDependencies(object controller)
        {
            FieldInfo[] currentDependencies =
                controller.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(x => x.GetCustomAttributes().Any(attr => attr.GetType() == typeof(InjectAttribute)))
                    .ToArray();

            foreach (FieldInfo currentDependency in currentDependencies)
            {
                Type currentDependencySource = currentDependency.GetType();

                if (!this.Components.ContainsKey(currentDependencySource))
                {
                    throw new InvalidOperationException("Cannot map dependency of type "
                                                        + currentDependencySource.Name +
                                                        ". It is not annotated with @Component ");

                }

                Type currentDependencyTarget = this.Components[currentDependencySource];

                object currentDependencyInstance = Activator.CreateInstance(currentDependencyTarget);

                currentDependency.SetValue(controller, currentDependencyInstance);

                this.ResolveDependencies(currentDependencyInstance);
            }
        }
    }


}
