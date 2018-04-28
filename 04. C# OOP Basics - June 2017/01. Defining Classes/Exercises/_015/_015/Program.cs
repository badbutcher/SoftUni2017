namespace _015
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (input == "Square")
            {
                int side = int.Parse(Console.ReadLine());

                Square square = new Square(side);
                Console.WriteLine(square.Draw());
            }
            else if (input == "Rectangle")
            {
                int width = int.Parse(Console.ReadLine());
                int length = int.Parse(Console.ReadLine());

                Rectangle rectangle = new Rectangle(width, length);
                Console.WriteLine(rectangle.Draw());
            }
        }
    }
}