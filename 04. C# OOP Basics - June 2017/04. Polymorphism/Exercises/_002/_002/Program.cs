namespace _002
{
    using System;

    public class Program
    {
        public static void Main()
        {
            try
            {
                string[] carData = Console.ReadLine().Split();
                string carName = carData[0];
                double carFuel = double.Parse(carData[1]);
                double carFuelUse = double.Parse(carData[2]);
                double carTankCapacity = double.Parse(carData[2]);

                Vehicle car = new Car(carFuel, carFuelUse, carTankCapacity);

                string[] truckData = Console.ReadLine().Split();
                string truckName = truckData[0];
                double truckFuel = double.Parse(truckData[1]);
                double truckFuelUse = double.Parse(truckData[2]);
                double truckTankCapacity = double.Parse(truckData[2]);

                Vehicle truck = new Truck(truckFuel, truckFuelUse, truckTankCapacity);

                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string[] data = Console.ReadLine().Split();
                    string command = data[0];
                    string vehicle = data[1];
                    double value = double.Parse(data[2]);

                    if (command == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            if (car.Drive(value))
                            {
                                Console.WriteLine("Car travelled {0} km", value);
                            }
                            else
                            {
                                Console.WriteLine("Car needs refueling");
                            }
                        }
                        else if (vehicle == "Truck")
                        {
                            if (truck.Drive(value))
                            {
                                Console.WriteLine("Truck travelled {0} km", value);
                            }
                            else
                            {
                                Console.WriteLine("Truck needs refueling");
                            }
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(value);
                        }
                    }
                }

                Console.WriteLine("Car: {0:F2}", car.FuelQuantity);
                Console.WriteLine("Truck: {0:F2}", truck.FuelQuantity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}