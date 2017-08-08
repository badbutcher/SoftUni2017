//namespace _02BlackBoxInteger
//{
using System;
using System.Linq;
using System.Reflection;

public class BlackBoxIntegerTests
{
    private static void Main()
    {
        Type classType = typeof(BlackBoxInt);
        BlackBoxInt blackBox = (BlackBoxInt)Activator.CreateInstance(classType, true);
        //ConstructorInfo blackBoxInfo = classType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { }, null);

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            else
            {
                string[] data = input.Split('_');
                string methodName = data[0];
                int value = int.Parse(data[1]);

                classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic).Invoke(blackBox, new object[] { value });

                object innerStateValue = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First()
                    .GetValue(blackBox);

                Console.WriteLine(innerStateValue);
            }
        }
    }
}

//}