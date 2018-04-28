namespace _010
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displaycement = 0;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displaycement)
            : this(model, power)
        {
            this.Displaycement = displaycement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displaycement, string efficiency)
            : this(model, power)
        {
            this.Displaycement = displaycement;
            this.Efficiency = efficiency;
        }

        public string Model { get; private set; }

        public int Power { get; private set; }

        public int Displaycement { get; private set; }

        public string Efficiency { get; private set; }
    }
}