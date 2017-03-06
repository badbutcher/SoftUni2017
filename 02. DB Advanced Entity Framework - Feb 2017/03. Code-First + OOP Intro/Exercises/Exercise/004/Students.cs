namespace _004
{
    public class Students
    {
        private string name;

        public static int instances = 0;

        public Students(string name)
        {
            this.Name = name;
            instances++;
        }

        public string Name { get; set; }
    }
}