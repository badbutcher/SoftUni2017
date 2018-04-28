namespace _003
{
    public class Cat : Felime
    {
        public Cat(string animalName, string animalType, double animalWeight, string livingRegion, string breed)
            : base(animalName, animalType, animalWeight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string MakeSound()
        {
            return "Meowwww";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{base.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}