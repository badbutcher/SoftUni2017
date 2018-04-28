namespace _002
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public virtual double FuelQuantity { get; set; }

        public double FuelConsumptionPerKm { get; private set; }

        public virtual double TankCapacity { get; private set; }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else
            {
                this.FuelQuantity += amount;
            }
        }

        public virtual bool Drive(double km, bool isAcOn)
        {
            var distanceTravled = km * this.FuelConsumptionPerKm;

            if (distanceTravled <= this.FuelQuantity)
            {
                this.FuelQuantity -= distanceTravled;
                return true;
            }

            return false;
        }

        public string TryTravelDistance(double distance, bool isAcOn)
        {
            if (this.Drive(distance, isAcOn))
            {
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public string TryTravelDistance(double distance)
        {
            return this.TryTravelDistance(distance, true);
        }
    }
}