namespace _002
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            string fileName = Console.ReadLine();
            string destination = Console.ReadLine();
            int parts = int.Parse(Console.ReadLine());

            Task.Run(() => SliceFile(fileName, destination, parts))
                .GetAwaiter()
                .GetResult();

            while (true)
            {
                Console.ReadLine();
            }
        }

        private static void SliceFile(string fileName, string destination, int parts)
        {
            for (int i = 0; i < 10110; i++)
            {
                Thread.Sleep(2000);
            }
        }
    }
}
