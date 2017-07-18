//namespace _002
//{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battert = battery;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Battert { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {GetType().Name} {this.Model} with {this.Battert} Batteries";
        }
    }
//}