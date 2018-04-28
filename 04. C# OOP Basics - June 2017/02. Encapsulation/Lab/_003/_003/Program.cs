//namespace _003
//{
using System;
using System.Collections.Generic;

public class Program
{
    private static void Main()
    {

        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            try
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        var bonus = double.Parse(Console.ReadLine());
        persons.ForEach(p => Console.WriteLine(p.ToString()));
    }
}

//}