using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010
{
    public class Engine
    {
        public Engine()
        {
        }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displaycement)
            : this(model, power)
        {
            this.Displaycement = displaycement;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Displaycement = 0;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displaycement, string efficiency)
            : this(model, power)
        {
            this.Displaycement = displaycement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displaycement { get; set; }

        public string Efficiency { get; set; }
    }
}