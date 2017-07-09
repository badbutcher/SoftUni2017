using System;

namespace _002
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm + 1.6, tankCapacity)
        {
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else
            {
                var lostAmount = (amount * 0.95);
                base.FuelQuantity += lostAmount;
            }
        }
    }
}