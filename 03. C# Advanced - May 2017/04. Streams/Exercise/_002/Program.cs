namespace _002
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../../TextFile.txt"))
            {
                using (StreamWriter whiter = new StreamWriter("../../Result.txt"))
                {
                    string line = reader.ReadLine();
                    int counter = 1;
                    while (line != null)
                    {
                        whiter.WriteLine("{0} {1}", counter++, line);
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}