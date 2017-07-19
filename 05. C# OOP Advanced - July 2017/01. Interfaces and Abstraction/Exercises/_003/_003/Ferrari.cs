namespace _003
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model { get; private set; }

        public string Driver { get; private set; }

        public string Break()
        {
            return "Brakes!";
        }

        public string Start()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{Model}/{Break()}/{Start()}/{Driver}";
        }
    }
}