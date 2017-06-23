namespace _006
{
    using System;
    using System.IO;
    using System.IO.Compression;

    class Program
    {
        static void Main()
        {
            Console.Write("Chose a file path: ");
            var filePath = Console.ReadLine();

            using (var reader = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (var writer = new FileStream("compress,text", FileMode.Create))
                {
                    using (var compressStream = new GZipStream(writer, CompressionMode.Compress))
                    {
                    }                  
                }
            }
        }
    }
}