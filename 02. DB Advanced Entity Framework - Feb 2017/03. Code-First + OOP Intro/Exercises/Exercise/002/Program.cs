namespace _002
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length == 0)
            {
                Person person = new Person();
                Console.WriteLine(person.Name + " " + person.Age);
            }
            else if (input.Length == 1)
            {
                int age = -1;
                bool check = int.TryParse(input[0], out age);

                if (check)
                {
                    Person person = new Person(age);
                    Console.WriteLine(person.Name + " " + person.Age);
                }
                else
                {
                    Person person = new Person(input[0]);
                    Console.WriteLine(person.Name + " " + person.Age);
                }
            }
            else
            {
                Person person = new Person(input[0], int.Parse(input[1]));
                Console.WriteLine(person.Name + " " + person.Age);
            }
        }
    }
}