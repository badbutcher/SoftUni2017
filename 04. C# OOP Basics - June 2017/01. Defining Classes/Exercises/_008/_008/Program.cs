namespace _008
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                double tireOnePressure = double.Parse(data[5]);
                int tireOneAge = int.Parse(data[6]);
                double tireTwoPressure = double.Parse(data[7]);
                int tireTwoAge = int.Parse(data[8]);
                double tireThreePressure = double.Parse(data[9]);
                int tireThreeAge = int.Parse(data[10]);
                double tireFourPressure = double.Parse(data[11]);
                int tireFourAge = int.Parse(data[12]);

                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Engine engine = new Engine(engineSpeed, enginePower);
                Tire tireOne = new Tire(tireOnePressure, tireOneAge);
                Tire tireTwo = new Tire(tireTwoPressure, tireTwoAge);
                Tire tireThree = new Tire(tireThreePressure, tireThreeAge);
                Tire tireFour = new Tire(tireFourPressure, tireFourAge);
                Tire[] tires = new Tire[4];
                tires[0] = tireOne;
                tires[1] = tireTwo;
                tires[2] = tireThree;
                tires[3] = tireFour;

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var result = cars.Where(a => a.Cargo.Type == "fragile" && a.Tire.Any(c => c.Pressure < 1));

                foreach (var item in result)
                {
                    Console.WriteLine(item.Model);
                }
            }
            else if (command == "flamable")
            {
                var result = cars.Where(a => a.Cargo.Type == "flamable" && a.Engine.Power > 250);

                foreach (var item in result)
                {
                    Console.WriteLine(item.Model);
                }
            }
        }
    }
}