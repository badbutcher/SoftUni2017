using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008
{
    public class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public Tire[] tire;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tire = tire;
        }
    }
}