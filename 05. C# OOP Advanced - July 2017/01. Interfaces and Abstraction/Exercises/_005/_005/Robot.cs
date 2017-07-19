namespace _005
{
    using _005.Interfaces;

    public class Robot : ICitizen, IRobort
    {
        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Id { get; private set; }

        public string Model { get; private set; }
    }
}