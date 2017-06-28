namespace _003
{
    using System;
    using System.Reflection;

    public class Program
    {
        static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family family = new Family();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                Person person = new Person();
                person.Name = name;
                person.Age = age;
                family.AddMember(person);
            }

            Console.WriteLine("{0} {1}",family.GetOldestMember().Name, family.GetOldestMember().Age);
        }
    }
}