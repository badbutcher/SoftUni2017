using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    class Program
    {
        static void Main()
        {
            string sourceFile = "../../image.jpg";
            string destinationDirectory = "../../clone.jpg";
            int parts = 5;

            Slice(sourceFile, destinationDirectory, parts);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            int counter = 1;

            using (FileStream file = new FileStream(sourceFile, FileMode.Open))
            {
                for (int i = 0; i < parts; i++)
                {
                    using (FileStream clone = new FileStream(destinationDirectory, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {

                            int read = file.Read(buffer, 0, buffer.Length);
                            if (read == 0)
                            {
                                break;
                            }

                            clone.Write(buffer, 0, read);
                        }
                    }
                }
            }
        }
    }
}