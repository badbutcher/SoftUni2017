namespace _014
{
    public class Siamese : Cat
    {
        private int earSize;

        public Siamese(string type, string name, int earSize)
            : base(type, name)
        {
            this.EarSize = earSize;
        }

        public int EarSize
        {
            get
            {
                return this.earSize;
            }
            set
            {
                this.earSize = value;
            }
        }

        public override string ToString()
        {
            return $"{Type} {Name} {earSize}";
        }
    }
}