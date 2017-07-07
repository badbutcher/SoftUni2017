using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    public abstract class Animal
    {
        private string animalName;
        private string animalType;
        private double animalWeight;
        private int foodEaten;

        public Animal(string animalName, string animalType, double animalWeight, int foodEaten)
        {

        }

        public string AnimalName
        {
            get
            {
                return this.animalName;
            }
            set
            {
                this.animalName = value;
            }
        }

        public string AnimalType
        {
            get
            {
                return this.animalType;
            }
            set
            {
                this.animalType = value;
            }
        }

        public double AnimalWeight
        {
            get
            {
                return this.animalWeight;
            }
            set
            {
                this.animalWeight = value;
            }
        }

        public int FoodEaten
        {
            get
            {
                return this.foodEaten;
            }
            set
            {
                this.foodEaten = value;
            }
        }


        public abstract string MakeSound();

        public abstract bool Eat(Food food);
    }
}