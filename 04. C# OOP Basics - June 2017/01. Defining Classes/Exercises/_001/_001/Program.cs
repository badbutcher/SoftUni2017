//namespace _001
//{
using System;
using System.Reflection;

public class Program
{
    private static void Main()
    {
        //Type personType = typeof(Person);
        //FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        //Console.WriteLine(fields.Length);

        Person pesho = new Person();
        pesho.Name = "Pesho";
        pesho.Age = 20;

        Person gosho = new Person()
        {
            Name = "Gosho",
            Age = 18
        };

        Person stamat = new Person();
        stamat.Name = "Stamat";
        stamat.Age = 43;
    }
}

//}