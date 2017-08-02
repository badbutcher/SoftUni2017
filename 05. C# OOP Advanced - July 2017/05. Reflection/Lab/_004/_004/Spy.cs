using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var item in methods.Where(a => a.Name.StartsWith("get")))
        {
            sb.AppendLine($"{item.Name} will return {item.ReturnType}");
        }

        foreach (var item in methods.Where(a => a.Name.StartsWith("set")))
        {
            sb.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}