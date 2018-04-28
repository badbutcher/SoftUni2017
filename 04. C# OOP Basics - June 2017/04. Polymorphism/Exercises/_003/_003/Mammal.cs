namespace _003
{
    public abstract class Mammal : Animal
    {
        public Mammal(string animalName, string animalType, double animalWeight, string livingRegion)
            : base(animalName, animalType, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{base.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}