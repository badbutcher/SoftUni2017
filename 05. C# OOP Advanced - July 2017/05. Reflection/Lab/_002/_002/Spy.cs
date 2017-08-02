using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] publicFields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var item in publicFields.Where(a => fields.Contains(a.Name))) //.GetCustomAttribute<CompilerGeneratedAttribute>() == null)
        {
            sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}