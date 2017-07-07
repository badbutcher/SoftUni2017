using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    public abstract class Felime : Mammal
    {
        public Felime(string animalName, string animalType, double animalWeight, int foodEaten, string livingRegion) 
            : base(animalName, animalType, animalWeight, foodEaten, livingRegion)
        {
        }
    }
}