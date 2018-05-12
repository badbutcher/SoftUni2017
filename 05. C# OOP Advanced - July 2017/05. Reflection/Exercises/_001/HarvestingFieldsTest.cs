//namespace _01HarestingFields
//{
using System;
using System.Reflection;

public class HarvestingFieldsTest
{
    public static void Main()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "HARVEST")
            {
                break;
            }
            else
            {
                switch (input)
                {
                    case "private":
                        PrintAllPrivate();
                        break;
                    case "protected":
                        PrintAllProtected();
                        break;
                    case "public":
                        PrintAllPublic();
                        break;
                    case "all":
                        PrintAll();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private static void PrintAllPrivate()
    {
        Type classType = Type.GetType("HarvestingFields");

        FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        foreach (var item in fields)
        {
            if (item.IsPrivate)
            {
                Console.WriteLine($"private {item.FieldType.Name} {item.Name}");
            }
        }
    }

    private static void PrintAllProtected()
    {
        Type classType = Type.GetType("HarvestingFields");

        FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        foreach (var item in fields)
        {
            if (item.IsFamily)
            {
                Console.WriteLine($"protected {item.FieldType.Name} {item.Name}");
            }
        }
    }

    private static void PrintAllPublic()
    {
        Type classType = Type.GetType("HarvestingFields");

        FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        foreach (var item in fields)
        {
            if (item.IsPublic)
            {
                Console.WriteLine($"public {item.FieldType.Name} {item.Name}");
            }
        }
    }

    private static void PrintAll()
    {
        Type classType = Type.GetType("HarvestingFields");

        FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        foreach (var item in fields)
        {
            Console.WriteLine($"{GetFieldType(item)} {item.FieldType.Name} {item.Name}");
        }
    }

    private static string GetFieldType(FieldInfo field)
    {
        if (field.IsPublic)
        {
            return "public";
        }
        else if (field.IsFamily)
        {
            return "protected";
        }
        else if (field.IsPrivate)
        {
            return "private";
        }

        return "none";
    }
}

//}