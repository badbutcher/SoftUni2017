namespace _005.Foods
{
    public abstract class Food
    {
        public Food(int hapinessPoints)
        {
            this.HapinessPoints = hapinessPoints;
        }

        private int HapinessPoints { get; set; }

        public int GetHapinessPoints()
        {
            return this.HapinessPoints;
        }
    }
}