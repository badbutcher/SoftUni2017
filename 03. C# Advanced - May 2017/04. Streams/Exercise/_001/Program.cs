namespace _001
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../../TextFile.txt"))
            {
                string line = reader.ReadLine();
                int count = 0;
                while (line != null)
                {
                    if (count % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }

                    line = reader.ReadLine();
                    count++;
                }
            }
        }
    }
}