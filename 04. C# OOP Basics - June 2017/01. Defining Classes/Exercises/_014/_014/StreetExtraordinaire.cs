namespace _014
{
    public class StreetExtraordinaire : Cat
    {
        public StreetExtraordinaire(string type, string name, int decibelsOfMeows)
            : base(type, name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public int DecibelsOfMeows { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.DecibelsOfMeows}";
        }
    }
}