namespace _015
{
    using System.Text;

    public class Rectangle : Figure
    {
        public Rectangle(int width, int length)
        {
            this.Width = width;
            this.Length = length;
        }

        public int Width { get; set; }
        public int Length { get; set; }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            string topAndBottomPart = $"|{new string('-', this.Width)}|";

            sb.AppendLine(topAndBottomPart);

            for (int i = 0; i < this.Length - 2; i++)
            {
                sb.AppendLine($"|{new string(' ', this.Width)}|");
            }

            sb.Append(topAndBottomPart);

            return sb.ToString();
        }
    }
}