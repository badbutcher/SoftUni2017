namespace _014
{
    public class Cymric : Cat
    {
        private decimal furLenght;

        public Cymric(string type, string name, decimal furLenght)
            : base(type, name)
        {
            this.FurLenght = furLenght;
        }

        public decimal FurLenght
        {
            get
            {
                return this.furLenght;
            }
            set
            {
                this.furLenght = value;
            }
        }

        public override string ToString()
        {
            return $"{Type} {Name} {furLenght:F2}";
        }
    }
}