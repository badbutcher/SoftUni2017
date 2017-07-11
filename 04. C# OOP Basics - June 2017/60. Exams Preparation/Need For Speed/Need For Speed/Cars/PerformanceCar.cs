namespace Need_For_Speed.Cars
{
    using System.Collections.Generic;

    public class PerformanceCar : Car
    {
        private List<string> addOns;

        public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability, List<string> addOns)
            : base(brand, model, yearOfProduction, horsepower += (horsepower * 50) / 100, acceleration, suspension -= (suspension * 25) / 100, durability)
        {
            this.AddOns = addOns;
        }

        public List<string> AddOns
        {
            get
            {
                return this.addOns;
            }
            set
            {
                this.addOns = value;
            }
        }
    }
}