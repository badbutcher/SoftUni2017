namespace _009
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<Rectangle> rects = new List<Rectangle>();
            for (int i = 0; i < input[0]; i++)
            {
                string[] data = Console.ReadLine().Split();
                string id = data[0];
                double width = double.Parse(data[1]);
                double height = double.Parse(data[2]);
                double x = double.Parse(data[3]);
                double y = double.Parse(data[4]);

                Rectangle rect = new Rectangle(id, width, height, x, y);
                rects.Add(rect);
            }

            for (int i = 0; i < input[1]; i++)
            {
                string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string idOne = data[0];
                string idTwo = data[1];

                Rectangle one = rects.FirstOrDefault(a => a.Id == idOne);
                Rectangle two = rects.FirstOrDefault(a => a.Id == idTwo);

                if (one.Check(two))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}