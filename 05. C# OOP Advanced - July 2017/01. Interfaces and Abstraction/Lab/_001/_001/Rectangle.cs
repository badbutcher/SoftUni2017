//namespace _001
//{
using System;

public class Rectangle : IDrawable
{
    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public void Draw()
    {
        for (int row = 0; row < this.Width; row++)
        {
            for (int col = 0; col < this.Height; col++)
            {
                if (row == 0 || row == this.Width - 1 || col == 0 || col == this.Height - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}

//}