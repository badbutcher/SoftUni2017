//namespace _003
//{
public class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height { get; private set; }

    public double Width { get; private set; }

    public override double CalculateArea()
    {
        return this.Width * this.Height;
    }

    public override double CalculatePerimeter()
    {
        return this.Width * 2 + this.Height * 2;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}

//}