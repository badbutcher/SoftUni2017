namespace Exam.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Photographer
    {
        public Photographer()
        {
            this.Lenses = new HashSet<Lens>();
            this.Accessories = new HashSet<Accessory>();
            this.WorkshopsParticipated = new HashSet<Workshop>();
            this.WorkshopsTrained = new HashSet<Workshop>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int? PrimaryCameraId { get; set; }

        public virtual Camera PrimaryCamera { get; set; }

        public int? SecondaryCameraId { get; set; }

        public virtual Camera SecondaryCamera { get; set; }

        public virtual ICollection<Lens> Lenses { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

        public virtual ICollection<Workshop> WorkshopsParticipated { get; set; }

        public virtual ICollection<Workshop> WorkshopsTrained { get; set; }
    }
}