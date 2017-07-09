namespace _002
{
    using System;

    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm + 0.9, tankCapacity)
        {
        }

        public override double FuelQuantity
        {
            set
            {
                if (value > this.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit in tank");
                }

                base.FuelQuantity = value;
            }
        }
    }
}