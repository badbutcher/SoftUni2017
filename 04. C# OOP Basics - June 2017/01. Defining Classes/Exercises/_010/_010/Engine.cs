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

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displaycement { get; set; }

        public char Efficiency { get; set; }
    }
}