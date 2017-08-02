//namespace _02BlackBoxInteger
//{
using System;
using System.Reflection;

public class BlackBoxIntegerTests
{
    private static void Main()
    {
        while (true)
        {
            Type classType = Type.GetType("BlackBoxInt");
            MethodInfo[] methods = classType.GetMethods();

            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }
            else
            {
                string[] data = input.Split('_');

                switch (data[0])
                {
                    case "Add":
                        break;
                    case "Subtract":
                        break;
                    case "Multiply":
                        break;
                    case "Divide":
                        break;
                    case "LeftShift":
                        break;
                    case "RightShift":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

//}