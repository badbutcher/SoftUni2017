namespace _003
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            MyStack<string> iterator = new MyStack<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    try
                    {
                        string[] data = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        switch (data[0])
                        {
                            case "Push":
                                iterator.Push(data.Skip(1).ToArray());
                                break;
                            case "Pop":
                                iterator.Pop();
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

            foreach (var item in iterator)
            {
                Console.WriteLine(item);
            }
        }
    }
}