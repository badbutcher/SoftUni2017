namespace _014
{
    public class StreetExtraordinaire : Cat
    {
        private int decibelsOfMeows;

        public StreetExtraordinaire(string type, string name, int decibelsOfMeows)
            : base(type, name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public int DecibelsOfMeows
        {
            get
            {
                return this.decibelsOfMeows;
            }
            set
            {
                this.decibelsOfMeows = value;
            }
        }

        public override string ToString()
        {
            return $"{Type} {Name} {decibelsOfMeows}";
        }
    }
}