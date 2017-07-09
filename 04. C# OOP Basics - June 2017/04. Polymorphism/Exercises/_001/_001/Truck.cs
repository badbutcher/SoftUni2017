namespace _001
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
            : base(fuelQuantity, fuelConsumptionPerKm + 1.6)
        {
        }

        public override void Refuel(double amount)
        {
            var lostAmount = (amount * 0.95);
            base.FuelQuantity += lostAmount;
        }
    }
}