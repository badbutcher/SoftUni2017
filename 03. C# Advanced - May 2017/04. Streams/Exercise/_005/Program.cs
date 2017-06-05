namespace _005
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string sourceFile = "../../text.txt";
            string destinationDirectory = "../../clone {0}.txt";
            int parts = 5;

            Slice(sourceFile, destinationDirectory, parts);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            int counter = 1;
            var buffer = new byte[4096];
            using (var fileReader = new FileStream(sourceFile, FileMode.Open))
            {
                long partSize = (long)Math.Ceiling((double)fileReader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    string format = string.Format(destinationDirectory, counter);
                    using (var fileWriter = new FileStream(format, FileMode.Create))
                    {
                        counter++;
                        int number = fileReader.Read(buffer, 0, buffer.Length);

                        while (number != 0 && fileWriter.Length <= partSize)
                        {
                            fileWriter.Write(buffer, 0, number);

                            number = fileReader.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}