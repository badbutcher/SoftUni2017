namespace _011
{
    public class Pokemon
    {
        private string name;
        private string element;
        private long health;

        public Pokemon(string name, string element, long health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public long Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
    }
}