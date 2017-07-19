namespace _005
{
    using _005.Interfaces;

    public class Human : ICitizen, IHuman
    {
        public Human(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }
}