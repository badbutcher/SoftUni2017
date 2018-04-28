namespace _011
{
    public class Pokemon
    {
        public Pokemon(string name, string element, long health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get; set; }

        public string Element { get; set; }

        public long Health { get; set; }
    }
}