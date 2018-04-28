//namespace _003
//{
using System;

public class Program
{
    public static void Main()
    {
        Shape rectangle = new Rectangle(5, 5);
        Console.WriteLine(rectangle.CalculateArea());
        Console.WriteLine(rectangle.CalculatePerimeter());
        Console.WriteLine(rectangle.Draw());
    }
}

//}