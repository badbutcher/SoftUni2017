namespace _004
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            using (FileStream file = new FileStream("../../image.jpg", FileMode.Open))
            {
                using (FileStream clone = new FileStream("../../clone.jpg", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];

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