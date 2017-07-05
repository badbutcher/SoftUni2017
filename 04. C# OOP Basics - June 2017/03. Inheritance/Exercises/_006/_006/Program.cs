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
                    try
                    {
                        string[] data = Console.ReadLine().Split();
                        switch (input)
                        {
                            case "Cat":
                                Cat cat = new Cat(data[0], int.Parse(data[1]), data[2]);
                                Console.WriteLine(input);
                                Console.WriteLine(string.Join(" ", data));
                                cat.ProduceSound();
                                break;

                            case "Dog":
                                Dog dog = new Dog(data[0], int.Parse(data[1]), data[2]);
                                Console.WriteLine(input);
                                Console.WriteLine(string.Join(" ", data));
                                dog.ProduceSound();
                                break;

                            case "Frog":
                                Frog frog = new Frog(data[0], int.Parse(data[1]), data[2]);
                                Console.WriteLine(input);
                                Console.WriteLine(string.Join(" ", data));
                                frog.ProduceSound();
                                break;

                            case "Kitten":
                                Kitten kitten = new Kitten(data[0], int.Parse(data[1]), data[2]);
                                Console.WriteLine(input);
                                Console.WriteLine(string.Join(" ", data));
                                kitten.ProduceSound();
                                break;

                            case "Tomcat":
                                Tomcat tomcat = new Tomcat(data[0], int.Parse(data[1]), data[2]);
                                Console.WriteLine(input);
                                Console.WriteLine(string.Join(" ", data));
                                tomcat.ProduceSound();
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