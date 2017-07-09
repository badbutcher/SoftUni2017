namespace _003
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string animalName, string animalType, double animalWeight, string livingRegion)
            : base(animalName, animalType, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion
        {
            get
            {
                return this.livingRegion;
            }
            set
            {
                this.livingRegion = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{base.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}