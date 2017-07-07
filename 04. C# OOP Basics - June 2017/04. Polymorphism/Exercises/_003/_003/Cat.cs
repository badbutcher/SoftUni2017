using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    public class Cat : Felime
    {
        private string breed;

        public Cat(string animalName, string animalType, double animalWeight, int foodEaten, string livingRegion, string breed) 
            : base(animalName, animalType, animalWeight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get
            {
                return this.breed;
            }
            set
            {
                this.breed = value;
            }
        }

        public override bool Eat(Food food)
        {
            return true;
        }

        public override string MakeSound()
        {
            throw new NotImplementedException();
        }
    }
}