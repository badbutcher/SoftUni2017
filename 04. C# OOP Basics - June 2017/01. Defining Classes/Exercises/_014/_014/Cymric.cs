namespace _014
{
    public class Cymric : Cat
    {
        public Cymric(string type, string name, decimal furLenght)
            : base(type, name)
        {
            this.FurLenght = furLenght;
        }

        public decimal FurLenght { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.FurLenght:F2}";
        }
    }
}