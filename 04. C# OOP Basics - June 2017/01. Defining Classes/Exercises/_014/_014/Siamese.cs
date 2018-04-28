namespace _014
{
    public class Siamese : Cat
    {
        public Siamese(string type, string name, int earSize)
            : base(type, name)
        {
            this.EarSize = earSize;
        }

        public int EarSize { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.EarSize}";
        }
    }
}