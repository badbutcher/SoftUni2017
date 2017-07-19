namespace _007
{
    using _007.Interfaces;

    public class Robot : IIdentify, IRobort
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