namespace _005
{
    using _005.Foods;
    using _005.Models.Foods;

    public class FoodFactory
    {
        public Food GetFood(string foodType)
        {
            switch (foodType.ToLower())
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "melon":
                    return new Melon();
                case "apple":
                    return new Apple();
                case "honeycake":
                    return new HoneyCake();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Junk();
            }
        }
    }
}