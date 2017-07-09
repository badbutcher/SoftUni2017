using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override double FuelQuantity
        {
            set
            {
                if (value > this.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }

                base.FuelQuantity = value;
            }
        }

        public override bool Drive(double km, bool isAcOn)
        {
            double requiredFuel = 0;
            if (isAcOn)
            {
                requiredFuel = km * (this.FuelConsumptionPerKm + 1.4);
            }
            else
            {
                requiredFuel = km * this.FuelConsumptionPerKm;
            }

            if (requiredFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= requiredFuel;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}