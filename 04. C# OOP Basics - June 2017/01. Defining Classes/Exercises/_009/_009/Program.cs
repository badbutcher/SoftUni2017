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
                int width = int.Parse(data[1]);
                int height = int.Parse(data[2]);
                int x = int.Parse(data[3]);
                int y = int.Parse(data[4]);

                Rectangle rect = new Rectangle(id, width, height, x, y);
                rects.Add(rect);
            }

            for (int i = 0; i < input[1]; i++)
            {
                string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string idOne = data[0];
                string idTwo = data[1];

                Rectangle one = rects.FirstOrDefault(a => a.ID == idOne);
                Rectangle two = rects.FirstOrDefault(a => a.ID == idTwo);

                if (Rectangle.Check(one, two))
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