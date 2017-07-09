namespace _003
{
    public abstract class Animal
    {
        private string animalName;
        private string animalType;
        private double animalWeight;
        private int foodEaten;

        public Animal(string animalName, string animalType, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
        }

        protected string AnimalName
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

        protected string AnimalType
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

        protected double AnimalWeight
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

        protected int FoodEaten
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

        public virtual void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }
    }
}