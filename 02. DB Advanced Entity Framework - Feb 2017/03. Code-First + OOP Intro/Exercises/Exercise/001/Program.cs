namespace _001
{
    using System;

    class Program
    {
        static void Main()
        {
            Person personOne = new Person("Pesho", 20);
            Person personTwo = new Person("Gosho", 18);
            Person personThree = new Person("Stamat", 43);

            Console.WriteLine(personOne.Name + " " + personOne.Age);
            Console.WriteLine(personTwo.Name + " " + personTwo.Age);
            Console.WriteLine(personThree.Name + " " + personThree.Age);
        }
    }
}