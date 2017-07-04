namespace _014
{
    public class Cat
    {
        private string type;
        private string name;
        
        public Cat(string type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}
