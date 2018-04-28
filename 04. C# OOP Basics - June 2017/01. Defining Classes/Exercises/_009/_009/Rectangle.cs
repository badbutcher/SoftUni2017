namespace _009
{
    public class Rectangle
    {
        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public string Id { get; private set; }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public double X { get; private set; }

        public double Y { get; private set; }

        public bool Check(Rectangle other)
        {
            //if (one.X < Math.Abs(two.X + two.Width) &&
            //    one.X + one.Width >= two.X &&
            //    one.Y < Math.Abs(two.Y - two.Height) &&
            //    one.Y + one.Height >= two.Y)
            //{
            //    return true;
            //}

            if (other.X + other.Width < this.X || 
                this.X + this.Width < other.X || 
                other.Y + other.Height < this.Y || 
                this.Y + this.Height < other.Y)
            {
                return false;
            }

            return true;
        }
    }
}