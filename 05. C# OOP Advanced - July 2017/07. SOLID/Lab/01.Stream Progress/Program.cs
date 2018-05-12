namespace _01.Stream_Progress
{
    using System;

    public class Program
    {
        public static void Main()
        {
            File file = new File("File", 100, 50);
            Music music = new Music("Pesho", "Power", 120, 75);
            StreamProgressInfo spi = new StreamProgressInfo(music);
            Console.WriteLine(spi.CalculateCurrentPercent());
        }
    }
}