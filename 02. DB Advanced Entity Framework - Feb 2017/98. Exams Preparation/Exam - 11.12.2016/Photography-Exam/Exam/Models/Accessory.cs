namespace Exam.Models
{
    public class Accessory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }

        public virtual Photographer Owner { get; set; }
    }
}