namespace _009
{
    public class Rectangle
    {
        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.ID = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public string ID { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

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