using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010
{
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
                Engine engine = new Engine(model, power);
                if (data.Length > 2)
                {
                    bool check = int.TryParse(data[2], out displacement);
                    if (data.Length >= 3 && check)
                    {
                        displacement = int.Parse(data[2]);
                        engine.Displaycement = displacement;
                    }
                    else
                    {
                        if (data.Length == 3)
                        {
                            char efficiency = char.Parse(data[2]);
                            engine.Efficiency = efficiency;
                        }
                    }

                    if (data.Length == 4)
                    {
                        char efficiency = char.Parse(data[3]);
                        engine.Efficiency = efficiency;
                    }
                }

                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < carCount; i++)
            {
                string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                Engine engine = engines.First(a => a.Model == data[1]);
                int weight;

                Car car = new Car(model, engine);
                if (data.Length > 2)
                {
                    bool check = int.TryParse(data[2], out weight);
                    if (data.Length >= 3 && check)
                    {
                        weight = int.Parse(data[2]);
                        car.Weight = weight;
                    }
                    else
                    {
                        if (data.Length == 3)
                        {
                            string color = data[2];
                            car.Color = color;
                        }
                    }

                    if (data.Length == 4)
                    {
                        string color = data[3];
                        car.Color = color;
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine("{0}:", car.Model);
                Console.WriteLine("  {0}:", car.Engine.Model);
                Console.WriteLine("    Power: {0}", car.Engine.Power);
                Console.WriteLine("    Displacement: {0}", car.Engine.Displaycement);
                Console.WriteLine("    Efficiency: {0}", car.Engine.Efficiency);
            }
        }
    }
}