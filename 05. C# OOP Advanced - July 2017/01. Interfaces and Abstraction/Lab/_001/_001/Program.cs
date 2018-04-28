//namespace _001
//{
using System;

public class Program
{
    public static void Main()
    {
        int radius = int.Parse(Console.ReadLine());
        IDrawable circle = new Circle(radius);

        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        IDrawable rect = new Rectangle(width, height);

        circle.Draw();
        rect.Draw();
    }
}

//}