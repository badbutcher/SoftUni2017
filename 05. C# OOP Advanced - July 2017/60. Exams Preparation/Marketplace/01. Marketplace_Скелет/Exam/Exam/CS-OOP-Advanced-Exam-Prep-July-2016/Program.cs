namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using System;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Parser;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Request;
    using System.Collections.Generic;
    using Lifecycle.Controller;
    using System.Text.RegularExpressions;
    using System.Reflection;

    public class Program
    {
        static void Main(string[] args)
        {
            AttributeParser parser = new AttributeParser();
            parser.Parse();

            

            string input = Console.ReadLine();
            while (input != "ILIENCI")
            {
                string[] tokens = input.Split();
                RequestMethod requestMethod = (RequestMethod)Enum.Parse(typeof(RequestMethod), tokens[0]);
                string uri = tokens[1];
                string[] uriTokens = uri.Split('/');

                Dictionary<string, ControllerActionPair> innerDictinary = parser.Controllers[requestMethod];

                foreach (var regexControllerPair in innerDictinary)
                {
                    string regex = regexControllerPair.Key;
                    ControllerActionPair controllerAction = regexControllerPair.Value;
                    var argumentsMapping = controllerAction.ArgumentsMapping;
                    int index = 0;
                    object[] argumentsToPass = new object[argumentsMapping.Count];
                    if (Regex.IsMatch(uri, regex))
                    {
                        foreach (var positionTypesPair in argumentsMapping)
                        {
                            string singleArgument = uriTokens[positionTypesPair.Key];
                            Type typeToCast = positionTypesPair.Value;
                            object argumentToPass = Convert.ChangeType(singleArgument, typeToCast);
                            argumentsToPass[index++] = argumentToPass;
                        }

                        object controller = controllerAction.Controller;
                        MethodInfo method = controllerAction.Action;

                        method.Invoke(controller, argumentsToPass);


                        break;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
