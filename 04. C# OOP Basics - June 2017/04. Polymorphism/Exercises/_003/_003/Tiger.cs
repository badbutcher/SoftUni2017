using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    public class Tiger : Felime
    {
        public Tiger(string animalName, string animalType, double animalWeight, int foodEaten, string livingRegion)
            : base(animalName, animalType, animalWeight, foodEaten, livingRegion)
        {
        }

        public override bool Eat(Food food)
        {
            throw new NotImplementedException();
        }

        public override string MakeSound()
        {
            throw new NotImplementedException();
        }
    }
}