namespace _001
{
    using System;
    using System.Reflection;

    public class Program
    {
        static void Main()
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            Person pesho = new Person();
            pesho.name = "Pesho";
            pesho.age = 20;

            Person gosho = new Person()
            {
                name = "Gosho",
                age = 18
            };

            Person stamat = new Person();
            stamat.name = "Stamat";
            stamat.age = 43;
        }
    }
}