namespace _007
{
    using System;

    public class Car
    {
        public Car(string model, decimal fuelAmount, decimal fuelUsedForOneKm, decimal distanceTraveled)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelUsedForOneKm = fuelUsedForOneKm;
            this.DistanceTraveled = distanceTraveled;
        }

        public string Model { get; set; }

        public decimal FuelAmount { get; set; }

        public decimal FuelUsedForOneKm { get; set; }

        public decimal DistanceTraveled { get; set; }

        public void Drive(decimal amountForKm)
        {
            if (this.FuelAmount < amountForKm * this.FuelUsedForOneKm)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.DistanceTraveled += amountForKm;
                this.FuelAmount -= amountForKm * this.FuelUsedForOneKm;
            }
        }
    }
}