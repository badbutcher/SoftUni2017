using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                double tireOnePressure = double.Parse(data[5]);
                int tireOneAngle = int.Parse(data[6]);
                double tireTwoPressure = double.Parse(data[7]);
                int tireTwoAngle = int.Parse(data[8]);
                double tireThreePressure = double.Parse(data[9]);
                int tireThreeAngle = int.Parse(data[10]);
                double tireFourPressure = double.Parse(data[11]);
                int tireFourAngle = int.Parse(data[12]);

                Car car = new Car(model,;
            }
        }
    }
}