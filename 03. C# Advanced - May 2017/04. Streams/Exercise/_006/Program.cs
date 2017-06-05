using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006
{
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