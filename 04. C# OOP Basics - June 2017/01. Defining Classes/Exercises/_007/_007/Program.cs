namespace _007
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                decimal fuel = decimal.Parse(data[1]);
                decimal fuelUse = decimal.Parse(data[2]);

                Car car = new Car(model, fuel, fuelUse, 0);

                cars.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();
                    string model = data[1];
                    decimal distance = decimal.Parse(data[2]);

                    var car = cars.Where(c => c.Model == model);

                    foreach (var item in car)
                    {
                        item.Drive(distance);
                    }
                }
            }

            foreach (var item in cars)
            {
                Console.WriteLine("{0} {1:F2} {2}", item.Model, item.FuelAmount, item.DistanceTraveled);
            }
        }
    }
}