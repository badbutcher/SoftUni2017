namespace _004
{
    using System;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            
            while (input != "End")
            {
                Students s = new Students(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(Students.instances);
        }
    }
}