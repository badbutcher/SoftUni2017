namespace _009
{
    using System;
    using System.Collections.Generic;

    public class Patients
    {
        public Patients()
        {
            this.Visitations = new HashSet<Visitations>();
            this.Diagnoses = new HashSet<Diagnoses>();
            this.PrescribedMedicaments = new HashSet<PrescribedMedicaments>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte ProfilePicture { get; set; }

        public bool MedicalInsurance { get; set; }

        public ICollection<Visitations> Visitations { get; set; }

        public ICollection<Diagnoses> Diagnoses { get; set; }

        public ICollection<PrescribedMedicaments> PrescribedMedicaments { get; set; }
    }
}