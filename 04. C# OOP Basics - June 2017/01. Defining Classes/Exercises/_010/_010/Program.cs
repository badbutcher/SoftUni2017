namespace _010
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int enginesCount = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                int power = int.Parse(data[1]);
                int displacement;

                if (data.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (data.Length == 3)
                {
                    bool check = int.TryParse(data[2], out displacement);
                    if (check)
                    {
                        displacement = int.Parse(data[2]);
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = data[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (data.Length == 4)
                {
                    displacement = int.Parse(data[2]);
                    string efficiency = data[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
            }

            int carCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < carCount; i++)
            {
                string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                Engine engine = engines.First(a => a.Model == data[1]);
                int weight;

                if (data.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (data.Length == 3)
                {
                    bool check = int.TryParse(data[2], out weight);
                    if (check)
                    {
                        weight = int.Parse(data[2]);
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        string color = data[2];
                        cars.Add(new Car(model, engine, color));
                    }
                }
                else if (data.Length == 4)
                {
                    weight = int.Parse(data[2]);
                    string color = data[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine("{0}:", car.Model);
                Console.WriteLine("  {0}:", car.Engine.Model);
                Console.WriteLine("    Power: {0}", car.Engine.Power);
                if (car.Engine.Displaycement != 0)
                {
                    Console.WriteLine("    Displacement: {0}", car.Engine.Displaycement);
                }
                else
                {
                    Console.WriteLine("    Displacement: n/a");
                }

                Console.WriteLine("    Efficiency: {0}", car.Engine.Efficiency);
                if (car.Weight != 0)
                {
                    Console.WriteLine("  Weight: {0}", car.Weight);
                }
                else
                {
                    Console.WriteLine("  Weight: n/a");
                }

                Console.WriteLine("  Color: {0}", car.Color);
            }
        }
    }
}