namespace _001
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] carData = Console.ReadLine().Split();
            string carName = carData[0];
            double carFuel = double.Parse(carData[1]);
            double carFuelUse = double.Parse(carData[2]);

            Vehicle car = new Car(carFuel, carFuelUse);

            string[] truckData = Console.ReadLine().Split();
            string truckName = truckData[0];
            double truckFuel = double.Parse(truckData[1]);
            double truckFuelUse = double.Parse(truckData[2]);

            Vehicle truck = new Truck(truckFuel, truckFuelUse);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
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
            }

            Console.WriteLine("Car: {0:F2}", car.FuelQuantity);
            Console.WriteLine("Truck: {0:F2}", truck.FuelQuantity);
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
                default:
                    break;
            }
        }
    }
}