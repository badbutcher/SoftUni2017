namespace _015
{
    using System.Text;

    public class Square : Figure
    {
        public Square(int side)
        {
            this.Side = side;
        }

        public int Side { get; set; }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            string topAndBottomPart = $"|{new string('-', this.Side)}|";

            sb.AppendLine(topAndBottomPart);

            for (int i = 0; i < this.Side - 2; i++)
            {
                sb.AppendLine($"|{new string(' ', this.Side)}|");
            }

            sb.Append(topAndBottomPart);

            return sb.ToString();
        }
    }
}