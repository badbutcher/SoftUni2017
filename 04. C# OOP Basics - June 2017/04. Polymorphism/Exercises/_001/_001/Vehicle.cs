namespace _001
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumptionPerKm { get; private set; }

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }

        public bool Drive(double km)
        {
            var distanceTravled = km * this.FuelConsumptionPerKm;

            if (distanceTravled <= this.FuelQuantity)
            {
                this.FuelQuantity -= distanceTravled;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string TryTravelDistance(double distance)
        {
            if (this.Drive(distance))
            {
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
    }
}