namespace _002
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override bool Drive(double km)
        {
            var distanceTravled = km * (base.FuelConsumptionPerKm + 0.9);

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
            base.FuelQuantity += amount;
        }
    }
}