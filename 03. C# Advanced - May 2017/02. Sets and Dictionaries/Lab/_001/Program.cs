namespace _001
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            SortedSet<string> result = new SortedSet<string>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (data[0] == "IN")
                    {
                        result.Add(data[1]);
                    }
                    else if (data[0] == "OUT")
                    {
                        result.Remove(data[1]);
                    }
                }
            }

            if (result.Count != 0)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}