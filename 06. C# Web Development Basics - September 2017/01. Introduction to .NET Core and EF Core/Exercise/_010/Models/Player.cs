namespace _010.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SqyadNumber { get; set; }

        public Team Team { get; set; }

        public Position Position { get; set; }

        public bool IsInjured { get; set; }
    }
}