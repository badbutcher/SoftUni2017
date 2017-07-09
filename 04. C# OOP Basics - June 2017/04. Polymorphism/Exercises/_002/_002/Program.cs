namespace _002
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] carData = Console.ReadLine().Split();
            double carFuel = double.Parse(carData[1]);
            double carFuelUse = double.Parse(carData[2]);
            double carTankCapacity = double.Parse(carData[3]);

            Vehicle car = new Car(carFuel, carFuelUse, carTankCapacity);

            string[] truckData = Console.ReadLine().Split();
            double truckFuel = double.Parse(truckData[1]);
            double truckFuelUse = double.Parse(truckData[2]);
            double truckTankCapacity = double.Parse(truckData[3]);

            Vehicle truck = new Truck(truckFuel, truckFuelUse, truckTankCapacity);

            string[] busData = Console.ReadLine().Split();
            double busFuel = double.Parse(busData[1]);
            double busFuelUse = double.Parse(busData[2]);
            double busTankCapacity = double.Parse(busData[3]);

            Vehicle bus = new Bus(busFuel, busFuelUse, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] data = Console.ReadLine().Split();
                    string command = data[0];
                    string vehicle = data[1];
                    double value = double.Parse(data[2]);

                    if (vehicle == "Car")
                    {
                        ExecuteAction(car, command, value);
                    }
                    else if (vehicle == "Truck")
                    {
                        ExecuteAction(truck, command, value);
                    }
                    else if (vehicle == "Bus")
                    {
                        ExecuteAction(bus, command, value);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }          
            }

            Console.WriteLine("Car: {0:F2}", car.FuelQuantity);
            Console.WriteLine("Truck: {0:F2}", truck.FuelQuantity);
            Console.WriteLine("Bus: {0:F2}", bus.FuelQuantity);
        }

        private static void ExecuteAction(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.TryTravelDistance(value));
                    break;
                case "Refuel":
                    vehicle.Refuel(value);
                    break;
                case "DriveEmpty":
                    Console.WriteLine(vehicle.TryTravelDistance(value, false));
                    break;
                    default:
                    break;
            }
        }
    }
}