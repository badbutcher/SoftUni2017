namespace _009
{
    using System;

    public class Rectangle
    {
        public Rectangle(string id, int width, int height, int x, int y)
        {
            this.ID = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public string ID { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public static bool Check(Rectangle one, Rectangle two)
        {
            //if (one.X < Math.Abs(two.X + two.Width) && 
            //    one.X + one.Width >= two.X && 
            //    one.Y < Math.Abs(two.Y - two.Height) && 
            //    one.Y + one.Height >= two.Y)
            //{
            //    return true;
            //}

            if (one.X + one.Width < two.X || two.X + two.Width < one.X || one.Y + one.Height < two.Y || two.Y + two.Height < one.Y)
            {
                return false;
            }

            return true;
        }
    }
}