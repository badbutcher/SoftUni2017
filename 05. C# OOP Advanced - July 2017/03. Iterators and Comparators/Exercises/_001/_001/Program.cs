namespace _001
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            ListyIterator<string> iterator = new ListyIterator<string>();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }
                    else
                    {
                        string[] data = input.Split();
                        switch (data[0])
                        {
                            case "Create":
                                iterator.Create(data.Skip(1).ToArray());
                                break;
                            case "Move":
                                Console.WriteLine(iterator.Move());
                                break;
                            case "Print":
                                iterator.Print();
                                break;
                            case "HasNext":
                                Console.WriteLine(iterator.HasNext());
                                break;
                            default:
                                break;
                        }
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