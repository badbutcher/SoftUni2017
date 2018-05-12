using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (var item in methods)
        {
            sb.AppendLine(item.Name);
        }

        return sb.ToString().Trim();
    }
}