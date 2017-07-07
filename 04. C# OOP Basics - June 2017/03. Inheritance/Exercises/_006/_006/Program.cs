namespace _006
{
    using System;

    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Beast!")
                {
                    break;
                }
                else
                {
                    string[] data = Console.ReadLine().Split();
                    int age;
                    if (!int.TryParse(data[1], out age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                    try
                    {
                        switch (input)
                        {
                            case "Cat":
                                Cat cat = new Cat(data[0], age, data[2]);
                                Console.WriteLine(cat.ToString());
                                break;
                            case "Dog":
                                Dog dog = new Dog(data[0], age, data[2]);
                                Console.WriteLine(dog.ToString());
                                break;
                            case "Frog":
                                Frog frog = new Frog(data[0], age, data[2]);
                                Console.WriteLine(frog.ToString());
                                break;
                            case "Kitten":
                                Kitten kitten = new Kitten(data[0], age);
                                Console.WriteLine(kitten.ToString());
                                break;
                            case "Tomcat":
                                Tomcat tomcat = new Tomcat(data[0], age);
                                Console.WriteLine(tomcat.ToString());
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}