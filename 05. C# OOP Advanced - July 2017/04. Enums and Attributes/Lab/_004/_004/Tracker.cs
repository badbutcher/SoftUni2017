//namespace _004
//{
using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var startUp = typeof(Program);
        var methods = startUp.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                foreach (SoftUniAttribute attr in methodInfo.GetCustomAttributes(false))
                {
                    Console.WriteLine($"{methodInfo.Name} is writen by {attr.Name}");
                }
            }
        }
    }
}

//}