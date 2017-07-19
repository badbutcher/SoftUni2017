namespace _007
{
    using _007.Interfaces;

    public class Human : ICitizen, IBuyer
    {
        public Human(string name, int age, string id, string birthdate)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}