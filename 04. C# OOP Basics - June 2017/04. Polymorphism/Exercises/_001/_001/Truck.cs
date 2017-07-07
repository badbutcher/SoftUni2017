namespace _001
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override bool Drive(double km)
        {
            var distanceTravled = km * (base.FuelConsumptionPerKm + 1.6);

            if (distanceTravled <= base.FuelQuantity)
            {
                base.FuelQuantity -= distanceTravled;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Refuel(double amount)
        {
            var lostAmount = (amount * 0.95);
            base.FuelQuantity += lostAmount;
        }
    }
}